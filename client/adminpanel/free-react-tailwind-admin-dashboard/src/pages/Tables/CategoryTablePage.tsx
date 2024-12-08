import { useEffect, useState } from 'react';
import CategoryTable from '../../components/Tables/CategoryTable';
import { Category, CategoryDto } from '../../types/types';
import { AddCategory, GetCategorys } from '../../services/categoryservice';
import CreateCategoryModal from '../../components/Modals/CreateCategoryModal';
import toast from 'react-hot-toast';
import { AddProduct } from '../../services/productservice';

const CategoryTablePage = () => {
  const [categories, setCategories] = useState<Category[]>([]);
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
  const onClose = async (productDto?: CategoryDto) => {
    if (productDto) {
      const loadingToast = toast.loading('Processing your request...', {
        duration: 0, // indefinite duration
      });
      try {
        console.log(productDto);

        const formData = new FormData();
        formData.append('name', productDto.name);
        formData.append('thumbnail', productDto.thumbnail[0]);
        const category = await AddCategory(formData);
        setCategories([category, ...categories]);
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
    const GetAllCategories = async () => {
      try {
        const data = await GetCategorys();

        setCategories(data);
      } catch (error) {
        console.error('Failed to fetch CateGetCategorys:', error);
      } finally {
      }
    };
    GetAllCategories();
  }, []);
  return (
    <>
      <CreateCategoryModal
        isOpen={isModalOpen}
        onClose={onClose}
      ></CreateCategoryModal>
      <div className="container">
        <div className="container flex justify-end items-center py-3 mt-20">
          <button
            onClick={(e) => {
              setIsModalOpen(true);
            }}
            className="bg-blue-500 text-white px-4 py-2 rounded-sm"
          >
            Add Category
          </button>
        </div>
        <CategoryTable categories={categories}></CategoryTable>
      </div>
    </>
  );
};

export default CategoryTablePage;
