export interface CartItem {
  productId: string;
  title: string;
  thumbnail: string;
  quantity: number;
  unityPrice: number;
  totalAmount: number;
}
export interface Cart {
  cartId: number;
  totalAmount: number;
  cartItems: CartItem[];
}
