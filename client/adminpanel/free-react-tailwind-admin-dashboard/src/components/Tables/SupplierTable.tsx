import { Supplier } from '../../types/types';

interface Props {
  suppliers: Supplier[];
}

const SupplierTable = (props: Props) => {
  return (
    <div className="relative overflow-x-auto shadow-md sm:rounded-lg">
      <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
        <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
          <tr>
            <th scope="col" className="px-6 py-3">
              Supplier name
            </th>
            <th scope="col" className="px-6 py-3">
              email
            </th>

            <th scope="col" className="px-6 py-3">
              Thumbnail
            </th>
          </tr>
        </thead>
        <tbody>
          {props.suppliers.map((supplier) => (
            <tr
              key={supplier.id}
              className="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700"
            >
              <th
                scope="row"
                className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white"
              >
                {supplier.name}
              </th>
              <td className="px-6 py-4">{supplier.email}</td>

              <td className="px-6 py-4">
                <img
                  className="w-10 h-10 rounded-full"
                  src={supplier.thumbnail}
                  alt="Jese image"
                />
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default SupplierTable;
