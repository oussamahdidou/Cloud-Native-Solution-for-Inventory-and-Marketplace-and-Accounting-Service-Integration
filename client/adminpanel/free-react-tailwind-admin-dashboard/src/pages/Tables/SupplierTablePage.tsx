import { useState, useEffect } from 'react';
import SupplierTable from '../../components/Tables/SupplierTable';
import { Supplier } from '../../types/types';
import { GetSuppliers } from '../../services/supplierservice';
const SupplierTablePage = () => {
  const [suppliers, setSuppliers] = useState<Supplier[]>([]);
  useEffect(() => {
    const GetAllProducts = async () => {
      try {
        const data = await GetSuppliers();

        setSuppliers(data);
      } catch (error) {
        console.error('Failed to fetch Products:', error);
      } finally {
      }
    };
    GetAllProducts();
  }, []);
  return (
    <div className="container">
      <div className="container flex justify-end items-center py-3 mt-20">
        <button className="bg-blue-500 text-white px-4 py-2 rounded-sm">
          Add Supplier
        </button>
      </div>
      <SupplierTable suppliers={suppliers}></SupplierTable>
    </div>
  );
};

export default SupplierTablePage;
