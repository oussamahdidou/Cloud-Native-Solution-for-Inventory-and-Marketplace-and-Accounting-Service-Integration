import React from 'react';
import ProductTable from '../../components/Tables/ProductTable';

type Props = {};

const ProductTablePage = (props: Props) => {
  return (
    <div className="container">
      <div className="container flex justify-end items-center py-3 mt-20">
        <button className="bg-blue-500 text-white px-4 py-2 rounded-sm">
          Add Product
        </button>
      </div>
      <ProductTable></ProductTable>
    </div>
  );
};

export default ProductTablePage;
