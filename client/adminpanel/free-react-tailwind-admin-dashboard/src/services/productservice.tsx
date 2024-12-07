import api from '../axios';
import { Product } from '../types/types';

export const GetProducts = async (): Promise<Product[]> => {
  const response = await api.get<Product[]>('stockservice/product/Products');
  return response.data;
};
