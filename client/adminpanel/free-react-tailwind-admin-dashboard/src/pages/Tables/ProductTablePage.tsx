import { useEffect, useState } from 'react';
import ProductTable from '../../components/Tables/ProductTable';
import { Product } from '../../types/types';
import { GetProducts } from '../../services/productservice';
import CreateProductModal from '../Modals/CreateProductModal';
const ProductTablePage = () => {
  const [products, setProducts] = useState<Product[]>([]);
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
      <CreateProductModal></CreateProductModal>
      <div className="container">
        <div className="container flex justify-end items-center py-3 mt-20">
          <button className="bg-blue-500 text-white px-4 py-2 rounded-sm">
            Add Product
          </button>
        </div>
        <ProductTable products={products}></ProductTable>
      </div>
    </>
  );
};

export default ProductTablePage;
