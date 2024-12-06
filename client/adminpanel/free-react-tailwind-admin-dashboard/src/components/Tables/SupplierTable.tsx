import React from 'react';

type Props = {};

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
          <tr className="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
            <th
              scope="row"
              className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white"
            >
              Apple MacBook Pro 17"
            </th>
            <td className="px-6 py-4">Silver</td>

            <td className="px-6 py-4">
              <img
                className="w-10 h-10 rounded-full"
                src="data:image/jpeg;base64,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"
                alt="Jese image"
              />
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  );
};

export default SupplierTable;
