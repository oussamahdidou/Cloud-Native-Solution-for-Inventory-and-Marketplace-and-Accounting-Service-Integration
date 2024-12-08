import { api, filesapi } from '../axios';
import { Product } from '../types/types';

export const GetProducts = async (): Promise<Product[]> => {
  const response = await api.get<Product[]>('stockservice/product/Products');
  return response.data;
};
export const AddProduct = async (formData: FormData): Promise<Product> => {
  const response = await filesapi.post<Product>(
    'stockservice/product',
    formData,
  );
  return response.data;
};
