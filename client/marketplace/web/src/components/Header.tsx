import React, { useContext, useEffect, useState } from "react";
import { SidebarContext } from "../Contexts/SidebarContext";
import { CartContext } from "../Contexts/CartContext";
import { Link } from "react-router-dom";
import Logo from "../img/logo.svg";
import { BsBag } from "react-icons/bs";
import { useAuth } from "../Contexts/useAuth";

const Header = () => {
  // header state
  const [isActive, setIsActive] = useState(false);
  const { isOpen, setIsOpen } = useContext(SidebarContext);
  const { cart } = useContext(CartContext);
  const defaultPoster = `${process.env.PUBLIC_URL + "/img/logo.svg"}`;
  const { isLoggedIn } = useAuth();
  useEffect(() => {
    window.addEventListener("scroll", () => {
      window.scrollY > 60 ? setIsActive(true) : setIsActive(false);
    });
  });

  return (
    <header
      className={`${
        isActive ? "bg-white py-4 shadow-md" : "bg-none py-6"
      } fixed w-full z-10 lg:px-8 transition-all`}
    >
      <div className="container mx-auto flex items-center justify-between h-full">
        <Link to={"/"}>
          <div className="w-[40px]">
            <img src={defaultPoster} alt="" />
          </div>
        </Link>

        {/* cart */}
        {isLoggedIn() ? (
          <div
            onClick={() => setIsOpen(!isOpen)}
            className="cursor-pointer flex relative"
          >
            <BsBag className="text-2xl" />
            <div className="bg-red-500 absolute -right-2 -bottom-2 text-[12px] w-[18px] h-[18px] text-white rounded-full flex justify-center items-center">
              {cart?.cartItems.length}
            </div>
          </div>
        ) : (
          <Link to={"/login"}>
            <p>Login</p>
          </Link>
        )}
      </div>
    </header>
  );
};

export default Header;
