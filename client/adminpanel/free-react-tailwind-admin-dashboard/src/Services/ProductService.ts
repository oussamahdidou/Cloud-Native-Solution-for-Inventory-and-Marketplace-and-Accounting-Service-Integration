import api from '../axios';
import { Product } from '../types/product';

export const ProductService = {
  async getAllProducts(): Promise<Product[]> {
    try {
      const response = await api.get<Product[]>(
        'stockservice/product/Products',
      );
      const products = response.data;

      return products;
    } catch (error) {
      console.error('error fetching product :', error);
      throw error;
    }
  },
};
