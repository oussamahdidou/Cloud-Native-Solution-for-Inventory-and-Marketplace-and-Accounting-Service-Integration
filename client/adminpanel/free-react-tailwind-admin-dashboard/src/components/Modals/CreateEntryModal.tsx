import { SubmitHandler, useForm } from 'react-hook-form';
import { EntreeDto, Product, Supplier } from '../../types/types';
import { useEffect, useState } from 'react';
import { GetProducts } from '../../services/productservice';
import { GetSuppliers } from '../../services/supplierservice';
interface ModalProps {
  isOpen: boolean;
  onClose: (data?: EntreeDto) => void; // A function type that takes no arguments and returns void
}
const CreateEntryModal = (props: ModalProps) => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<EntreeDto>();
  const onSubmit: SubmitHandler<EntreeDto> = (data) => {
    data.entreeDate = new Date(data.entreeDate).toISOString();
    props.onClose(data);
    console.log(data);
  };
  const [products, setProducts] = useState<Product[]>([]);
  const [suppliers, setSuppliers] = useState<Supplier[]>([]);
  useEffect(() => {
    const GetEntrys = async () => {
      const productssReponse = await GetProducts();
      setProducts(productssReponse);
      const fournisseursReponse = await GetSuppliers();
      setSuppliers(fournisseursReponse);
    };
    GetEntrys();
  }, []);
  if (!props.isOpen) {
    return null;
  }
  return (
    <div
      onClick={(e) => props.onClose()}
      id="crud-modal"
      className="   overflow-y-auto overflow-x-hidden fixed top-0 right-0  left-0 z-999 flex justify-center items-center w-full md:inset-0 h-[calc(100%-1rem)] max-h-full"
    >
      <div
        onClick={(e) => {
          e.stopPropagation();
        }}
        className="relative p-4 w-full max-w-md max-h-full"
      >
        <div className="relative bg-white rounded-lg shadow dark:bg-gray-700">
          <div className="flex items-center justify-between p-4 md:p-5 border-b rounded-t dark:border-gray-600">
            <h3 className="text-lg font-semibold text-gray-900 dark:text-white">
              Create New Product
            </h3>
            <button
              onClick={(e) => props.onClose()}
              type="button"
              className="text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm w-8 h-8 ms-auto inline-flex justify-center items-center dark:hover:bg-gray-600 dark:hover:text-white"
              data-modal-toggle="crud-modal"
            >
              <svg
                className="w-3 h-3"
                aria-hidden="true"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 14 14"
              >
                <path
                  stroke="currentColor"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6"
                />
              </svg>
              <span className="sr-only">Close modal</span>
            </button>
          </div>
          <form className="p-4 md:p-5" onSubmit={handleSubmit(onSubmit)}>
            <div className="grid gap-4 mb-4 grid-cols-2">
              <div className="col-span-2">
                <label
                  htmlFor="quantity"
                  className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                >
                  Quantity
                </label>
                <input
                  type="number"
                  id="name"
                  className="bg-gray-50 border border-gray-300 outline-none text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                  placeholder="Type product name"
                  {...register('quantite', { required: true })}
                />
                {errors.quantite && (
                  <span className="text-red-500">quantite is required</span>
                )}
              </div>
              <div className="col-span-2 sm:col-span-1">
                <label
                  htmlFor="quantity"
                  className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                >
                  quantity
                </label>
                <input
                  type="datetime-local"
                  id="quantity"
                  className="bg-gray-50 border outline-none border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                  placeholder="999"
                  {...register('entreeDate', { required: true })}
                />
                {errors.entreeDate && (
                  <span className="text-red-500">entreeDate is required</span>
                )}
              </div>

              <div className="col-span-2 sm:col-span-1">
                <label
                  htmlFor="supplier"
                  className="block mb-2 text-sm  font-medium text-gray-900 dark:text-white"
                >
                  Supplier
                </label>
                <select
                  id="supplierId"
                  className="bg-gray-50 border outline-none border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-500 focus:border-primary-500 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                  {...register('supplierId', { required: true })}
                >
                  <option>Select supplier</option>
                  {suppliers.map((supplier) => (
                    <option value={supplier.id} key={supplier.id}>
                      {supplier.name}
                    </option>
                  ))}
                </select>
                {errors.supplierId && (
                  <span className="text-red-500">supplier is required</span>
                )}
              </div>
              <div className="col-span-2 sm:col-span-1">
                <label
                  htmlFor="category"
                  className="block mb-2 text-sm font-medium outline-none text-gray-900 dark:text-white"
                >
                  Product
                </label>
                <select
                  id="product"
                  className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-500 focus:border-primary-500 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                  {...register('productId', { required: true })}
                >
                  <option>Select Product</option>
                  {products.map((category) => (
                    <option value={category.id} key={category.id}>
                      {category.name}
                    </option>
                  ))}
                </select>
                {errors.productId && (
                  <span className="text-red-500">category is required</span>
                )}
              </div>
            </div>

            <button
              type="submit"
              className="text-white inline-flex items-center bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800"
            >
              <svg
                className="me-1 -ms-1 w-5 h-5"
                fill="currentColor"
                viewBox="0 0 20 20"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  fill-rule="evenodd"
                  d="M10 5a1 1 0 011 1v3h3a1 1 0 110 2h-3v3a1 1 0 11-2 0v-3H6a1 1 0 110-2h3V6a1 1 0 011-1z"
                  clip-rule="evenodd"
                ></path>
              </svg>
              Add new Entree
            </button>
          </form>
        </div>
      </div>
    </div>
  );
};
export default CreateEntryModal;
