import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import { RouterProvider } from "react-router-dom";
import { routes } from "./Routes/Routes";
import CartProvider from "./Contexts/CartContext";
import SidebarProvider from "./Contexts/SidebarContext";
import { UserProvider } from "./Contexts/useAuth";

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);
root.render(
  <React.StrictMode>
    <UserProvider>
      <SidebarProvider>
        <CartProvider>
          <RouterProvider router={routes}></RouterProvider>
        </CartProvider>
      </SidebarProvider>
    </UserProvider>
  </React.StrictMode>
);
reportWebVitals();
