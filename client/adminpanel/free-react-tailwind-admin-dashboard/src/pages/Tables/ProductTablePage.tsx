import { useEffect, useState } from 'react';
import ProductTable from '../../components/Tables/ProductTable';
import { Product, productDto } from '../../types/types';
import { AddProduct, GetProducts } from '../../services/productservice';
import CreateProductModal from '../../components/Modals/CreateProductModal';
import toast, { Toaster } from 'react-hot-toast';

const ProductTablePage = () => {
  const [products, setProducts] = useState<Product[]>([]);
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
  const onClose = async (productDto?: productDto) => {
    if (productDto) {
      const loadingToast = toast.loading('Processing your request...', {
        duration: 0, // indefinite duration
      });
      try {
        console.log(productDto);

        const formData = new FormData();
        formData.append('name', productDto.name);
        formData.append('thumbnail', productDto.thumbnail[0]);
        formData.append('description', productDto.description);
        formData.append('price', productDto.price.toString());
        formData.append('quantity', productDto.quantity.toString());
        formData.append('categoryId', productDto.categoryId);
        formData.append('supplierId', productDto.supplierId.toString());

        const product = await AddProduct(formData);
        setProducts([product, ...products]);
        toast.success('Action completed successfully!', {
          id: loadingToast, // update the previous toast
        });
      } catch (error) {
        toast.error('Something went wrong!', {
          id: loadingToast, // update the previous toast
        });
      }
    }
    setIsModalOpen(false);
  };
  useEffect(() => {
    const GetAllProducts = async () => {
      try {
        const data = await GetProducts();

        setProducts(data);
      } catch (error) {
        console.error('Failed to fetch Products:', error);
      } finally {
      }
    };
    GetAllProducts();
  }, []);

  return (
    <>
      <Toaster></Toaster>
      <CreateProductModal
        isOpen={isModalOpen}
        onClose={onClose}
      ></CreateProductModal>
      <div className="container">
        <div className="container flex justify-end items-center py-3 mt-20">
          <button
            onClick={(e) => {
              setIsModalOpen(true);
            }}
            className="bg-blue-500 text-white px-4 py-2 rounded-sm"
          >
            Add Product
          </button>
        </div>
        <ProductTable products={products}></ProductTable>
      </div>
    </>
  );
};

export default ProductTablePage;
