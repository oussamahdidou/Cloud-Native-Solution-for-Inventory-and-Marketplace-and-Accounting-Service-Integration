import api from '../axios';
import { Performance } from '../types/types';

export const SortiesOfTheweek = async (): Promise<Performance[]> => {
  const response = await api.get<Performance[]>(
    'stockservice/dashboard/sorties/weekly-performance',
  );
  return response.data;
};
export const EntriesOfTheweek = async (): Promise<Performance[]> => {
  const response = await api.get<Performance[]>(
    'stockservice/dashboard/entries/weekly-performance',
  );
  return response.data;
};
export const SortiesOfThemonth = async (): Promise<Performance[]> => {
  const response = await api.get<Performance[]>(
    'stockservice/dashboard/sorties/monthly-performance',
  );
  return response.data;
};
export const EntriesOfThemonth = async (): Promise<Performance[]> => {
  const response = await api.get<Performance[]>(
    'stockservice/dashboard/entries/monthly-performance',
  );
  return response.data;
};
