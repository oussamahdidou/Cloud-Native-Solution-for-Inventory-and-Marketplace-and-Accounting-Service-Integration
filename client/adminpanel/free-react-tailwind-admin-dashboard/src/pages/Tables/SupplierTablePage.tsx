import React from 'react';
import SupplierTable from '../../components/Tables/SupplierTable';

type Props = {};

const SupplierTablePage = (props: Props) => {
  return (
    <div className="container">
      <div className="container flex justify-end items-center py-3 mt-20">
        <button className="bg-blue-500 text-white px-4 py-2 rounded-sm">
          Add Supplier
        </button>
      </div>
      <SupplierTable></SupplierTable>
    </div>
  );
};

export default SupplierTablePage;
