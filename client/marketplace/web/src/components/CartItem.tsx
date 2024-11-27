import React, { useContext } from "react";
import { Link } from "react-router-dom";
import { IoMdAdd, IoMdClose, IoMdRemove } from "react-icons/io";
import { CartContext } from "../Contexts/CartContext";
import { CartItem } from "../models/CartModels";

// Define prop type for CartItem
interface CartItemProps {
  item: CartItem;
}

const CartItemCard: React.FC<CartItemProps> = ({ item }) => {
  const { removeFromCart, addToCart, decreaseAmount } = useContext(CartContext);

  return (
    <div className="flex gap-x-4 py-2 lg:px-6 border-b border-gray-200 w-full font-light text-gray-500">
      <div className="w-full min-h-[150px] flex items-center gap-x-4">
        {/* Image */}
        <Link to={`/product/${item.productId}`}>
          <img className="max-w-[80px]" src={item.thumbnail} alt="" />
        </Link>
        <div className="w-full flex flex-col">
          {/* Title and remove icon */}
          <div className="flex justify-between mb-2">
            <Link
              to={`/product/${item.productId}`}
              className="text-sm uppercase font-medium max-w-[240px] text-primary hover:underline"
            >
              {item.title}
            </Link>
            <div
              onClick={() => removeFromCart(item.productId)}
              className="text-xl cursor-pointer"
            >
              <IoMdClose className="text-gray-500 hover:text-red-500 transition" />
            </div>
          </div>
          <div className="flex gap-x-2 h-[36px] text-sm">
            {/* Quantity */}
            <div className="flex flex-1 max-w-[100px] items-center h-full border text-primary font-medium">
              <div
                onClick={() => decreaseAmount(item.productId)}
                className="h-full flex-1 flex justify-center items-center cursor-pointer"
              >
                <IoMdRemove />
              </div>
              <div className="h-full flex justify-center items-center px-2">
                {item.quantity}
              </div>
              <div
                onClick={() => addToCart(item)}
                className="h-full flex flex-1 justify-center items-center cursor-pointer"
              >
                <IoMdAdd />
              </div>
            </div>
            {/* Item Price */}
            <div className="flex flex-1 justify-around items-center">
              ${item.unityPrice}
            </div>
            {/* Final Price */}
            <div className="flex flex-1 justify-end items-center text-primary font-medium">
              ${parseFloat(item.totalAmount.toFixed(2))}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CartItemCard;
