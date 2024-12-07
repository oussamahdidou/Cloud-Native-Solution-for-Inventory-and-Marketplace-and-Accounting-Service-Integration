import React, { useEffect, useState } from 'react';
import StockChangesTable from '../../components/Tables/StockChangesTable';

import {
  GetStockEntrees,
  GetStockSorties,
} from '../../services/Stockioservice';
import { StockEntry, StockSortie } from '../../types/types';
import { mapStockEntriesAndSortiesToIO } from '../../mappers/mappers';

type Props = {};

const StockChangesTablePage = (props: Props) => {
  const [entries, setEntries] = useState<StockEntry[]>([]);
  const [sorties, setSorties] = useState<StockSortie[]>([]);
  useEffect(() => {
    const GetAllIOStock = async () => {
      try {
        const entries = await GetStockEntrees();
        const sorties = await GetStockSorties();

        setEntries(entries);
        setSorties(sorties);
      } catch (error) {
        console.error('Failed to fetch Products:', error);
      } finally {
      }
    };
    GetAllIOStock();
  }, []);
  return (
    <div className="container">
      <div className="container flex justify-end items-center py-3 mt-20">
        <button className="bg-blue-500 text-white px-4 py-2 rounded-sm">
          Add Entree
        </button>
      </div>
      <StockChangesTable
        ioStock={mapStockEntriesAndSortiesToIO(entries, sorties)}
      ></StockChangesTable>
    </div>
  );
};

export default StockChangesTablePage;
