import React, { useEffect, useState } from 'react';
import StockChangesTable from '../../components/Tables/StockChangesTable';

import {
  AddEntry,
  GetStockEntrees,
  GetStockSorties,
} from '../../services/Stockioservice';
import { EntreeDto, StockEntry, StockSortie } from '../../types/types';
import { mapStockEntriesAndSortiesToIO } from '../../mappers/mappers';
import toast from 'react-hot-toast';
import CreateEntryModal from '../../components/Modals/CreateEntryModal';

type Props = {};

const StockChangesTablePage = (props: Props) => {
  const [entries, setEntries] = useState<StockEntry[]>([]);
  const [sorties, setSorties] = useState<StockSortie[]>([]);
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
  const onClose = async (entreeDto?: EntreeDto) => {
    if (entreeDto) {
      const loadingToast = toast.loading('Processing your request...', {
        duration: 0, // indefinite duration
      });
      try {
        console.log(entreeDto);

        const entree = await AddEntry(entreeDto);
        setEntries([entree, ...entries]);
        toast.success('Action completed successfully!', {
          id: loadingToast, // update the previous toast
        });
      } catch (error) {
        toast.error('Something went wrong!', {
          id: loadingToast, // update the previous toast
        });
      }
    }
    setIsModalOpen(false);
  };
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
    <>
      <CreateEntryModal
        isOpen={isModalOpen}
        onClose={onClose}
      ></CreateEntryModal>
      <div className="container">
        <div className="container flex justify-end items-center py-3 mt-20">
          <button
            onClick={(e) => {
              setIsModalOpen(true);
            }}
            className="bg-blue-500 text-white px-4 py-2 rounded-sm"
          >
            Add Entree
          </button>
        </div>
        <StockChangesTable
          ioStock={mapStockEntriesAndSortiesToIO(entries, sorties)}
        ></StockChangesTable>
      </div>
    </>
  );
};

export default StockChangesTablePage;
