import { api } from '../axios';
import { EntreeDto, StockEntry, StockSortie } from '../types/types';

export const GetStockEntrees = async (): Promise<StockEntry[]> => {
  const response = await api.get<StockEntry[]>('stockservice/entrees');
  return response.data;
};
export const GetStockSorties = async (): Promise<StockSortie[]> => {
  const response = await api.get<StockSortie[]>('stockservice/sortie/sorties');
  return response.data;
};
export const AddEntry = async (entreeDto: EntreeDto): Promise<StockEntry> => {
  const response = await api.post<StockEntry>(
    'stockservice/entrees',
    entreeDto,
  );
  return response.data;
};
