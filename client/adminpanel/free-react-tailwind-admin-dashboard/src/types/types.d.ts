export interface Category {
  id: string;
  name: string;
  thumbnail: string;
}

export interface Supplier {
  id: number;
  name: string;
  email: string;
  thumbnail: string;
}

export interface Product {
  id: string;
  name: string;
  thumbnail: string;
  description: string;
  price: number;
  quantity: number;
  category: Category;
  supplier: Supplier;
}

export interface StockEntry {
  id: number;
  quantite: number;
  entreeDate: string;
  product: Product;
  supplier: Supplier;
}
export interface StockSortie {
  id: number;
  quantite: number;
  sortieDate: string;
  product: Product;
}
export interface StockIO {
  id: number;
  type: string;
  quantite: number;
  Date: string;
  productname: string;
}
export interface Performance {
  date: string;
  total: number;
}
