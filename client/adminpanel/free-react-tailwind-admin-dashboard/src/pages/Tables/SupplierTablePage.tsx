import { useState, useEffect } from 'react';
import SupplierTable from '../../components/Tables/SupplierTable';
import { Supplier, SupplierDto } from '../../types/types';
import { AddSupplier, GetSuppliers } from '../../services/supplierservice';
import CreateSupplierModal from '../../components/Modals/CreateSupplierModal';
import toast from 'react-hot-toast';
const SupplierTablePage = () => {
  const [suppliers, setSuppliers] = useState<Supplier[]>([]);
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
  const onClose = async (supplierDto?: SupplierDto) => {
    if (supplierDto) {
      const loadingToast = toast.loading('Processing your request...', {
        duration: 0, // indefinite duration
      });
      try {
        console.log(supplierDto);

        const formData = new FormData();
        formData.append('name', supplierDto.name);
        formData.append('email', supplierDto.email);
        formData.append('thumbnail', supplierDto.thumbnail[0]);
        const supplier = await AddSupplier(formData);
        setSuppliers([supplier, ...suppliers]);
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
    const GetAllSuppliers = async () => {
      try {
        const data = await GetSuppliers();

        setSuppliers(data);
      } catch (error) {
        console.error('Failed to fetch Products:', error);
      } finally {
      }
    };
    GetAllSuppliers();
  }, []);

  return (
    <>
      <CreateSupplierModal
        isOpen={isModalOpen}
        onClose={onClose}
      ></CreateSupplierModal>
      <div className="container">
        <div className="container flex justify-end items-center py-3 mt-20">
          <button
            onClick={(e) => {
              setIsModalOpen(true);
            }}
            className="bg-blue-500 text-white px-4 py-2 rounded-sm"
          >
            Add Supplier
          </button>
        </div>
        <SupplierTable suppliers={suppliers}></SupplierTable>
      </div>
    </>
  );
};

export default SupplierTablePage;
