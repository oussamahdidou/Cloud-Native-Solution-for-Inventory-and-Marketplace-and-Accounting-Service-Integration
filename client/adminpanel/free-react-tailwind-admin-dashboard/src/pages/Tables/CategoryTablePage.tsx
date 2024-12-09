import { useEffect, useState } from 'react';
import CategoryTable from '../../components/Tables/CategoryTable';
import { Category, CategoryDto } from '../../types/types';
import { AddCategory, GetCategorys } from '../../services/categoryservice';
import CreateCategoryModal from '../../components/Modals/CreateCategoryModal';
import toast, { Toaster } from 'react-hot-toast';

const CategoryTablePage = () => {
  const [categories, setCategories] = useState<Category[]>([]);
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
  const onClose = async (categorydto?: CategoryDto) => {
    if (categorydto) {
      const loadingToast = toast.loading('Processing your request...', {
        duration: 0, // indefinite duration
      });
      try {
        console.log(categorydto);

        const formData = new FormData();
        formData.append('name', categorydto.name);
        formData.append('thumbnail', categorydto.thumbnail[0]);
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
      <Toaster></Toaster>
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
