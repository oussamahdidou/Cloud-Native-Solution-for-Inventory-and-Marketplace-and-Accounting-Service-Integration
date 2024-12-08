import axios from "axios";
import { ProductDetail, ProductItem } from "../models/ProductModels";
import { useAuth } from "../Contexts/useAuth";

const apiBase = "http://159.89.248.249/gateway";

export const GetProducts = async (): Promise<ProductItem[]> => {
  const reponse = await axios.get<ProductItem[]>(
    `${apiBase}/marketplace/Product/GetProducts`
  );
  return reponse.data;
};
export const GetProductDetail = async (
  productId: string
): Promise<ProductDetail> => {
  const reponse = await axios.get<ProductDetail>(
    `${apiBase}/marketplace/Product/ProductDetail/${productId}`
  );
  return reponse.data;
};
