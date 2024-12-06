import React from 'react';
import StockChangesTable from '../../components/Tables/StockChangesTable';

type Props = {};

const StockChangesTablePage = (props: Props) => {
  return (
    <div className="container">
      <div className="container flex justify-end items-center py-3 mt-20">
        <button className="bg-blue-500 text-white px-4 py-2 rounded-sm">
          Add Entree
        </button>
      </div>
      <StockChangesTable></StockChangesTable>
    </div>
  );
};

export default StockChangesTablePage;
