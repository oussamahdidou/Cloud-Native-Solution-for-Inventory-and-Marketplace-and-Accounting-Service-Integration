import { api } from '../axios';
import { Supplier } from '../types/types';

export const GetSuppliers = async (): Promise<Supplier[]> => {
  const response = await api.get<Supplier[]>('stockservice/Supplier/Suppliers');
  return response.data;
};
