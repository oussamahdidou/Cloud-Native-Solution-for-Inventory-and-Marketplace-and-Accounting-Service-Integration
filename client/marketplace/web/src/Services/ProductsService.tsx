import axios from "axios";
import { ProductDetail, ProductItem } from "../models/ProductModels";
const apiBase = "http://localhost:5000/gateway";
// JWT Token
const token =
  "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJzdWIiOiJzdHJpbmciLCJ1bmlxdWVfbmFtZSI6ImYzYjMyODFmLTM0ZDktNDFjOS1hY2FhLWVjNWI2MDRjNzAwZSIsInJvbGUiOiJDdXN0b21lciIsIm5iZiI6MTczMjQ2NjM1OCwiZXhwIjoxNzMzMDcxMTU4LCJpYXQiOjE3MzI0NjYzNTgsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMSJ9.KhZ54g_cfVNvi0OwMMiQ6EfQSQCYI2gnVdTZMVHhdXk1ByQTXgBZc2ke-sV0DiPpk1BfW57MlJhDvIoOYOq_wQ";
export const apiClient = axios.create({
  baseURL: "http://localhost:5000/gateway", // Replace with your API base URL
  headers: {
    Authorization: `Bearer ${token}`,
    "Content-Type": "application/json", // Optional: Include if sending JSON
  },
});
// Set token to Axios default headers
export const GetProducts = async (): Promise<ProductItem[]> => {
  const reponse = await apiClient.get<ProductItem[]>(
    `${apiBase}/marketplace/Product/GetProducts`
  );
  return reponse.data;
};
export const GetProductDetail = async (
  productId: string
): Promise<ProductDetail> => {
  const reponse = await apiClient.get<ProductDetail>(
    `${apiBase}/marketplace/Product/ProductDetail/${productId}`
  );
  return reponse.data;
};
