import { useEffect, useState } from 'react';
import CategoryTable from '../../components/Tables/CategoryTable';
import { Category } from '../../types/types';
import { GetCategorys } from '../../services/categoryservice';

const CategoryTablePage = () => {
  const [categories, setCategories] = useState<Category[]>([]);
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
    <div className="container">
      <div className="container flex justify-end items-center py-3 mt-20">
        <button className="bg-blue-500 text-white px-4 py-2 rounded-sm">
          Add Category
        </button>
      </div>
      <CategoryTable categories={categories}></CategoryTable>
    </div>
  );
};

export default CategoryTablePage;
