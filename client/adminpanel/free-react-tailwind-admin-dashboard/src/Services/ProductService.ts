import api from '../axios';
import { Product } from '../types/product';
import { CategoryService } from './CategoryService';

export const ProductService = {
    async getAllProducts(): Promise<Product[]> {
        try {
            const response = await api.get<Product[]>('/api/product/Products'); 
            const products =  response.data;
            for (let product of products)
            {
                try{
                    const CategoryResponse = await CategoryService.getCategoryById(product.categoryId);
                    product.categoryName = CategoryResponse.name;
                }catch(error)
                {
                    console.error('error fetching categories from service', error);
                }
                
            }
            return products;
        }catch(error)
        {
            console.error('error fetching product :', error);
            throw error;
        }
      
    },
  };