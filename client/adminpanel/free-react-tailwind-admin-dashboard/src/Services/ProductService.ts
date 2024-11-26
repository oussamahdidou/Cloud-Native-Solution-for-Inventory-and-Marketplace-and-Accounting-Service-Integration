import api from '../axios';

export const getAllProducts = async () =>
{
    try{
        const response = await api.get('/api/product/Products');
        return response.data;
    }catch (error){
        console.error("error fetching products",error);
        throw error;
    }
}