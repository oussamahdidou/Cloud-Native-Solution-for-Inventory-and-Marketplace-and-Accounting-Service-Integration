import { api } from '../axios';
import { Category } from '../types/types';

export const GetCategorys = async (): Promise<Category[]> => {
  const response = await api.get<Category[]>(
    'stockservice/category/Categories',
  );
  return response.data;
};
