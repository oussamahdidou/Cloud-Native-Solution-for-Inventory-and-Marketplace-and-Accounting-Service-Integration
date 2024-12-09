import React from "react";

import * as Yup from "yup";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { useAuth } from "../Contexts/useAuth";
import toast, { Toaster } from "react-hot-toast";
type Props = {};
type RegisterFormInputs = {
  email: string;
  username: string;
  password: string;
  confirmPassword: string;
};
const validation = Yup.object().shape({
  email: Yup.string().email().required("email is required"),
  username: Yup.string().required("username is required"),
  password: Yup.string().required("password is required"),
  confirmPassword: Yup.string()
    .oneOf([Yup.ref("password")], "Passwords must match")
    .required("Confirm password is required"),
});
const RegisterPage = (props: Props) => {
  const { RegisterUser } = useAuth();
  const {
    register,
    handleSubmit,
    formState: error,
  } = useForm<RegisterFormInputs>({ resolver: yupResolver(validation) });
  const handleRegister = (form: RegisterFormInputs) => {
    toast.loading("Waiting...");

    RegisterUser(form.email, form.username, form.password);
  };
  return (
    <>
      <Toaster></Toaster>
      <div className="flex flex-col justify-center py-12 sm:px-6 lg:px-8">
        <div className="mt-8 sm:mx-auto sm:w-full sm:max-w-md">
          <div className="bg-white py-8 px-4 shadow sm:rounded-lg sm:px-10">
            <form onSubmit={handleSubmit(handleRegister)}>
              <div>
                <label
                  className="block text-sm font-medium text-gray-700"
                  htmlFor="username"
                >
                  Username
                </label>
                <div className="mt-1">
                  <input
                    className="appearance-none block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
                    type="text"
                    id="username"
                    {...register("username")}
                  />
                  {error.errors.username ? (
                    <span className="text-red-600">
                      {error.errors.username?.message}
                    </span>
                  ) : (
                    <></>
                  )}
                </div>
              </div>

              <div className="mt-6">
                <label
                  className="block text-sm font-medium text-gray-700"
                  htmlFor="email"
                >
                  Email address
                </label>
                <div className="mt-1">
                  <input
                    className="appearance-none block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
                    type="text"
                    id="email"
                    {...register("email")}
                  />
                  {error.errors.email ? (
                    <span className="text-red-600">
                      {error.errors.email?.message}
                    </span>
                  ) : (
                    <></>
                  )}
                </div>
              </div>

              <div className="mt-6">
                <label
                  className="block text-sm font-medium text-gray-700"
                  htmlFor="password"
                >
                  Password
                </label>
                <div className="mt-1">
                  <input
                    className="appearance-none block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
                    type="password"
                    id="password"
                    {...register("password")}
                  />
                  {error.errors.password ? (
                    <span className="text-red-600">
                      {error.errors.password?.message}
                    </span>
                  ) : (
                    <></>
                  )}
                </div>
              </div>

              <div className="mt-6">
                <label
                  className="block text-sm font-medium text-gray-700"
                  htmlFor="confirm-password"
                >
                  Confirm Password
                </label>
                <div className="mt-1">
                  <input
                    className="appearance-none block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
                    type="password"
                    id="confirm-password"
                    {...register("confirmPassword")}
                  />
                  {error.errors.confirmPassword ? (
                    <span className="text-red-600">
                      {error.errors.confirmPassword?.message}
                    </span>
                  ) : (
                    <></>
                  )}
                </div>
              </div>

              <div className="mt-6">
                <button
                  className="group relative w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
                  type="submit"
                >
                  Sign up
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </>
  );
};

export default RegisterPage;
