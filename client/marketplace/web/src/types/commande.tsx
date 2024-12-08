export interface CommandeProduct {
  productId: string;
  commandeId: number;
  quantity: number;
  product: Product;
}

export interface Product {
  productId: string;
  marqueName: string;
  marqueIcon: string;
  name: string;
  description: string;
  price: number;
  quantity: number;
  thumbnail: string;
  categoryId: string;
  category: any; // Change `any` to a specific interface if `category` has a structure.
  commandeProducts: any[]; // Change `any[]` if necessary.
  cartProducts: any[]; // Change `any[]` if necessary.
}

export interface Customer {
  customerId: string;
  userName: string;
  commandes: any[]; // Change `any[]` if necessary.
}

export interface Commande {
  commandeId: number;
  payementId: string | null;
  orderDate: string;
  status: string;
  totaleAmount: number;
  customerId: string;
  customer: Customer;
  commandeProducts: CommandeProduct[];
}
