import axios from "axios";

const apiBase = "http://localhost:5000/gateway";

export const Login = async (username: string, password: string) => {
  try {
    const reponse = await axios.post<any>(`${apiBase}/users/Account/Login`, {
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
  password: string
) => {
  try {
    const reponse = await axios.post<any>(`${apiBase}/users/Account/Register`, {
      userName: userName,
      email: email,
      password: password,
    });
    return reponse.data;
  } catch (error: any) {
    throw new Error(error.response);
  }
};
