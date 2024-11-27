import axios from "axios";
import { Cart } from "../models/CartModels";
import { useAuth } from "../Contexts/useAuth";

const apiBase = "http://localhost:5000/gateway";

// Set token to Axios default headers
export const GetCart = async (): Promise<Cart> => {
  const reponse = await axios.get<Cart>(`${apiBase}/marketplace/Cart/GetCart`);
  return reponse.data;
};
export const AddProductToCart = async (productId: string, cartId: number) => {
  const reponse = await axios.post(
    `${apiBase}/marketplace/Cart/AddProductToCart`,
    {
      productId: productId,
      cartId: cartId,
    }
  );
  return reponse.data;
};
export const RemoveProductFromCart = async (
  productId: string,
  cartId: number
) => {
  const reponse = await axios.post(
    `${apiBase}/marketplace/Cart/RemoveProductFromCart`,
    {
      productId: productId,
      cartId: cartId,
    }
  );
  return reponse.data;
};
export const IncreaseProductQuantity = async (
  productId: string,
  cartId: number
) => {
  const reponse = await axios.post(
    `${apiBase}/marketplace/Cart/IncreaseProductQuantity`,
    {
      productId: productId,
      cartId: cartId,
    }
  );
  return reponse.data;
};
export const DecreaseProductQuantity = async (
  productId: string,
  cartId: number
) => {
  const reponse = await axios.post(
    `${apiBase}/marketplace/Cart/DecreaseProductQuantity`,
    {
      productId: productId,
      cartId: cartId,
    }
  );
  return reponse.data;
};
