import axios from "axios";
// import { showErrorModal } from "../helpers/handlers";
const apiBase = "http://localhost:8080";

export const Login = async (username: string, password: string) => {
  try {
    const reponse = await axios.post<any>(`${apiBase}/Api/Auth/Login`, {
      userName: username,
      password: password,
    });
    return reponse.data;
  } catch (error: any) {
    throw new Error(error.response);
  }
};
export const Register = async (
  email: string,
  userName: string,
  password: string,
  role: string
) => {
  try {
    const reponse = await axios.post<any>(`${apiBase}/Api/Auth/Register`, {
      userName: userName,
      email: email,
      password: password,
      role: role,
    });
    return reponse.data;
  } catch (error: any) {
    throw new Error(error.response);
  }
};
