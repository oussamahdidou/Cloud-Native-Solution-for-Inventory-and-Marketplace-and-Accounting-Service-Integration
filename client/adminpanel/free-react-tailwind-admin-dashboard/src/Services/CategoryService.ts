import api from '../axios';
import {Category} from '../types/Category';

export class  CategoryService {
    static async getCategoryById(categoryId: string): Promise<Category>
    {
        try{
            const Categoryresponse = await api.get<Category>(`/api/category/${categoryId}`)
            console.log(Categoryresponse.data);
            return Categoryresponse.data;
        }catch(error)
        {
            console.error('error fetching Categories :', error);
            throw error;
        }
    }
}
