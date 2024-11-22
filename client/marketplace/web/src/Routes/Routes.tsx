import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import DashboardPage from "../Pages/DashboardPage";
import Home from "../Pages/Home";
import ProductDetails from "../Pages/ProductDetails";

export const routes = createBrowserRouter([
  {
    path: "/",
    element: <App></App>,
    children: [
      { path: "/dashboard", element: <DashboardPage></DashboardPage> },
      { path: "", element: <Home></Home> },
      { path: "/product/:id", element: <ProductDetails /> },
    ],
  },
]);
