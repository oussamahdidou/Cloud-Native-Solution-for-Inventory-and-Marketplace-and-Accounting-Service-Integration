import { useEffect, useState } from 'react';
import { Route, Routes, useLocation } from 'react-router-dom';

import Loader from './common/Loader';
import PageTitle from './components/PageTitle';
import Chart from './pages/Chart';
import ECommerce from './pages/Dashboard/ECommerce';

import DefaultLayout from './layout/DefaultLayout';
import ProductTablePage from './pages/Tables/ProductTablePage';
import CategoryTablePage from './pages/Tables/CategoryTablePage';
import SupplierTablePage from './pages/Tables/SupplierTablePage';
import StockChangesTablePage from './pages/Tables/StockChangesTablePage';

function App() {
  const [loading, setLoading] = useState<boolean>(true);
  const { pathname } = useLocation();

  useEffect(() => {
    window.scrollTo(0, 0);
  }, [pathname]);

  useEffect(() => {
    setTimeout(() => setLoading(false), 1000);
  }, []);

  return loading ? (
    <Loader />
  ) : (
    <DefaultLayout>
      <Routes>
        <Route
          index
          element={
            <>
              <PageTitle title="eCommerce Dashboard | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <ECommerce />
            </>
          }
        />
        <Route
          path="/table/product"
          element={
            <>
              <PageTitle title="Product Table | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <ProductTablePage />
            </>
          }
        />
        <Route
          path="/table/category"
          element={
            <>
              <PageTitle title="Category Table | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <CategoryTablePage />
            </>
          }
        />
        <Route
          path="/table/supplier"
          element={
            <>
              <PageTitle title="Supplier Table | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <SupplierTablePage />
            </>
          }
        />

        <Route
          path="/table/stockChanges"
          element={
            <>
              <PageTitle title="StockChanges Table | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <StockChangesTablePage />
            </>
          }
        />
        <Route
          path="/chart"
          element={
            <>
              <PageTitle title="Basic Chart | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <Chart />
            </>
          }
        />
      </Routes>
    </DefaultLayout>
  );
}

export default App;
