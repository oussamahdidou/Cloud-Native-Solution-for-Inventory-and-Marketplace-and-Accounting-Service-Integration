import React, { createContext, useState, useEffect, ReactNode } from "react";
import { ProductItem } from "./CartContext";

// Define types
interface Product {
  id: number;
  title: string;
  price: number;
  description: string;
  category: string;
  image: string;
  rating: {
    rate: number;
    count: number;
  };
}

interface ProductContextType {
  products: ProductItem[];
}

export const ProductContext = createContext<ProductContextType>(
  {} as ProductContextType
);

interface ProductProviderProps {
  children: ReactNode;
}

const ProductProvider: React.FC<ProductProviderProps> = ({ children }) => {
  // products state
  const [products, setProducts] = useState<ProductItem[]>([]);

  // fetch products
  useEffect(() => {
    const fetchProducts = async () => {
      const response = await fetch("https://fakestoreapi.com/products");
      const data = await response.json();
      setProducts(data);
    };
    fetchProducts();
  }, []);

  return (
    <ProductContext.Provider value={{ products }}>
      {children}
    </ProductContext.Provider>
  );
};

export default ProductProvider;
