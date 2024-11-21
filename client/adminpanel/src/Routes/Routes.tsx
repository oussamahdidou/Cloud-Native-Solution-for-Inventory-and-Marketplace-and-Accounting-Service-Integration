import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import DashboardPage from "../Pages/DashboardPage";

export const routes = createBrowserRouter([
  {
    path: "/",
    element: <App></App>,
    children: [
      { path: "/dashboard", element: <DashboardPage></DashboardPage> },
    ],
  },
]);
