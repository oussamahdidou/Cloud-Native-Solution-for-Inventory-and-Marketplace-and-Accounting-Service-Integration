import { api, filesapi } from '../axios';
import { Category } from '../types/types';

export const GetCategorys = async (): Promise<Category[]> => {
  const response = await api.get<Category[]>(
    'stockservice/category/Categories',
  );
  return response.data;
};
export const AddCategory = async (formData: FormData): Promise<Category> => {
  const response = await filesapi.post<Category>(
    'stockservice/category',
    formData,
  );
  return response.data;
};
