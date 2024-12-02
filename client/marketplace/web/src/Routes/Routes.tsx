import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import DashboardPage from "../Pages/DashboardPage";
import Home from "../Pages/Home";
import ProductDetails from "../Pages/ProductDetails";
import LoginPage from "../Pages/LoginPage";
import RegisterPage from "../Pages/RegisterPage";

export const routes = createBrowserRouter([
  {
    path: "/",
    element: <App></App>,
    children: [
      { path: "/dashboard", element: <DashboardPage></DashboardPage> },
      { path: "", element: <Home></Home> },
      { path: "/product/:id", element: <ProductDetails /> },
      { path: "/login", element: <LoginPage /> },
      { path: "/register", element: <RegisterPage /> },
    ],
  },
]);
