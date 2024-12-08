import { api, filesapi } from '../axios';
import { Supplier } from '../types/types';

export const GetSuppliers = async (): Promise<Supplier[]> => {
  const response = await api.get<Supplier[]>('stockservice/Supplier/Suppliers');
  return response.data;
};
export const AddSupplier = async (formData: FormData): Promise<Supplier> => {
  const response = await filesapi.post<Supplier>(
    'stockservice/Supplier',
    formData,
  );
  return response.data;
};
