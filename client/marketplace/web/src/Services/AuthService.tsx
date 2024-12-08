import axios from "axios";

const apiBase = "http://159.89.248.249/gateway";

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
      username: userName,
      emailAddress: email,
      password: password,
    });
    return reponse.data;
  } catch (error: any) {
    throw new Error(error.response);
  }
};
