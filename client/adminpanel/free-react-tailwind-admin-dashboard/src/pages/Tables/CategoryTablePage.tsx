import React from 'react';
import CategoryTable from '../../components/Tables/CategoryTable';

type Props = {};

const CategoryTablePage = (props: Props) => {
  return (
    <div className="container">
      <div className="container flex justify-end items-center py-3 mt-20">
        <button className="bg-blue-500 text-white px-4 py-2 rounded-sm">
          Add Category
        </button>
      </div>
      <CategoryTable></CategoryTable>
    </div>
  );
};

export default CategoryTablePage;
