import axios from "axios";
import { useAuth } from "../Contexts/useAuth";

const apiBase = "http://localhost:5000/gateway";

// Set token to Axios default headers
export const createPaypal = async (
  commandeId: number,
  amount: number
): Promise<string> => {
  const reponse = await axios.post<any>(
    `${apiBase}/marketplace/Paypal/create`,
    { commandeId: commandeId, amount: amount }
  );
  return reponse.data.approvalUrl;
};
