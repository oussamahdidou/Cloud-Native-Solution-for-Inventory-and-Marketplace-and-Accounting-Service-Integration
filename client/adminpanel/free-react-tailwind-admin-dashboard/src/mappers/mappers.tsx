import { StockEntry, StockSortie, StockIO } from '../types/types';

export const mapStockEntriesAndSortiesToIO = (
  entries: StockEntry[],
  sorties: StockSortie[],
): StockIO[] => {
  const stockIOList: StockIO[] = [];

  // Map StockEntry to StockIO
  entries.forEach((entry) => {
    stockIOList.push({
      id: entry.id,
      type: 'Entree',
      quantite: entry.quantite,
      Date: entry.entreeDate, // Use entreeDate for entry records
      productname: entry.product.name,
    });
  });
  sorties.forEach((sortie) => {
    stockIOList.push({
      id: sortie.id,
      type: 'Sortie',
      quantite: sortie.quantite,
      Date: sortie.sortieDate,
      productname: sortie.product.name,
    });
  });

  return stockIOList;
};
