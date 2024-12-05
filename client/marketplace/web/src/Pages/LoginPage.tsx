import React from "react";
import { Link } from "react-router-dom";
import { yupResolver } from "@hookform/resolvers/yup";
import * as Yup from "yup";
import { useAuth } from "../Contexts/useAuth";
import { useForm } from "react-hook-form";
type Props = {};
type LoginFormInputs = {
  username: string;
  password: string;
};
const validation = Yup.object().shape({
  username: Yup.string().required("username is required"),
  password: Yup.string().required("password is required"),
});
const LoginPage = (props: Props) => {
  const { login } = useAuth();
  const {
    register,
    handleSubmit,
    formState: error,
  } = useForm<LoginFormInputs>({ resolver: yupResolver(validation) });
  const handleLogin = (form: LoginFormInputs) => {
    login(form.username, form.password);
  };
  return (
    <div className="flex items-center justify-center h-screen">
      <div className="mx-auto max-w-screen-xl  px-4 py-16 sm:px-6 lg:px-8 shadow-lg">
        <div className="mx-auto max-w-lg text-center">
          <h1 className="text-2xl font-bold sm:text-3xl">Welcome Back!</h1>
          <p className="mt-4 text-gray-600">
            login to our store so u can add items to your cart and buy products
          </p>
        </div>

        <form
          className="mx-auto mb-0 mt-8 max-w-md space-y-4"
          onSubmit={handleSubmit(handleLogin)}
        >
          <div>
            <label className="sr-only" htmlFor="email">
              Email
            </label>
            <div className="relative">
              <input
                placeholder="Enter your email"
                className="w-full rounded-lg border-gray-300 p-4 pe-12 text-sm shadow-sm focus:outline-none focus:ring-2 focus:ring-purple-400 focus:border-transparent"
                id="email"
                type="text"
                {...register("username")}
              />
              <span className="absolute inset-y-0 end-0 grid place-content-center px-4">
                <svg
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  fill="none"
                  className="h-6 w-6 text-gray-400"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    d="M16 12a4 4 0 10-8 0 4 4 0 008 0zm0 0v1.5a2.5 2.5 0 005 0V12a9 9 0 10-9 9m4.5-1.206a8.959 8.959 0 01-4.5 1.207"
                    stroke-width="2"
                    stroke-linejoin="round"
                    stroke-linecap="round"
                  ></path>
                </svg>
              </span>
            </div>
            {error.errors.username ? (
              <span className="text-red-600">
                {error.errors.username?.message}
              </span>
            ) : (
              <></>
            )}
          </div>

          <div>
            <label className="sr-only" htmlFor="password">
              Password
            </label>
            <div className="relative">
              <input
                placeholder="Enter your password"
                className="w-full rounded-lg border-gray-300 p-4 pe-12 text-sm shadow-sm focus:outline-none focus:ring-2 focus:ring-purple-400 focus:border-transparent"
                id="password"
                type="password"
                {...register("password")}
              />
              <span className="absolute inset-y-0 end-0 grid place-content-center px-4">
                <svg
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  fill="none"
                  className="h-6 w-6 text-gray-400"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"
                    stroke-width="2"
                    stroke-linejoin="round"
                    stroke-linecap="round"
                  ></path>
                  <path
                    d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z"
                    stroke-width="2"
                    stroke-linejoin="round"
                    stroke-linecap="round"
                  ></path>
                </svg>
              </span>
            </div>
            {error.errors.password ? (
              <span className="text-red-600">
                {error.errors.password?.message}
              </span>
            ) : (
              <></>
            )}
          </div>

          <div className="flex items-center justify-between">
            <p className="text-sm text-gray-600">
              No account yet?
              <Link to={`/register`}>
                <span className="underline">Create one</span>
              </Link>
            </p>
            <button
              className="inline-block rounded-lg bg-purple-600 px-5 py-3 text-sm font-medium text-white focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-opacity-50"
              type="submit"
            >
              Sign In
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default LoginPage;
