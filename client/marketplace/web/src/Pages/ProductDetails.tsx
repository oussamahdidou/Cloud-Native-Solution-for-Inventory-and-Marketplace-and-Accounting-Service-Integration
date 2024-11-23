import React, { useContext } from "react";
import { useParams } from "react-router-dom";
import { CartContext } from "../Contexts/CartContext";
import { ProductContext } from "../Contexts/ProductContext";

const ProductDetails: React.FC = () => {
  // Get the product id from URL
  const { id } = useParams<{ id: string }>();

  return (
    <section className="pt-[450px] md:pt-32 pb-[400px] md:pb-12 lg:py-32 h-screen flex items-center">
      <div className="container mx-auto">
        {/* Image and text wrapper */}
        <div className="flex flex-col lg:flex-row items-center gap-4">
          {/* Image */}
          <div className="flex flex-1 justify-center items-center mb-8 lg:mb-0">
            <img
              className="w-full aspect-square"
              src={
                "https://static.nike.com/a/images/t_PDP_936_v1/f_auto,q_auto:eco/38ddd566-f90d-4d55-9ab6-695a52fd83cc/WMNS+NIKE+COURT+LEGACY+NN.png"
              }
            />
          </div>
          {/* Text */}
          <div className="flex-1 text-center lg:text-left">
            <h1 className="text-[26px] text-4xl font-medium mb-2 max-w-[450px] mx-auto lg:mx-0">
              Product Name
            </h1>
            <div className="text-2xl text-red-500 font-medium mb-6">$ 10</div>
            <p className="mb-8">the best product ever buy it please .</p>
            <button
              onClick={() => {}}
              className="bg-black py-4 px-8 text-white"
            >
              Add to cart
            </button>
          </div>
        </div>
      </div>
    </section>
  );
};

export default ProductDetails;
