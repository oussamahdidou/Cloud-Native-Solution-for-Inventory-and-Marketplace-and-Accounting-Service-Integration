import React, { useContext } from "react";
import { useParams } from "react-router-dom";
import { CartContext } from "../Contexts/CartContext";
import { ProductContext } from "../Contexts/ProductContext";

const ProductDetails: React.FC = () => {
  // Get the product id from URL
  const { id } = useParams<{ id: string }>();

  // Safely get context values
  const cartContext = useContext(CartContext);
  const productContext = useContext(ProductContext);

  // Ensure context is not undefined
  if (!cartContext || !productContext) {
    return (
      <section className="h-screen flex justify-center items-center">
        Context not available.
      </section>
    );
  }

  const { addToCart } = cartContext;
  const { products } = productContext;

  // Get the single product based on id
  const product = products.find(
    (item: { id: number }) => item.id === Number(id)
  );

  // If product is not found
  if (!product) {
    return (
      <section className="h-screen flex justify-center items-center">
        Loading...
      </section>
    );
  }

  // Destructure product
  const { name, price, image } = product;

  return (
    <section className="pt-[450px] md:pt-32 pb-[400px] md:pb-12 lg:py-32 h-screen flex items-center">
      <div className="container mx-auto">
        {/* Image and text wrapper */}
        <div className="flex flex-col lg:flex-row items-center">
          {/* Image */}
          <div className="flex flex-1 justify-center items-center mb-8 lg:mb-0">
            <img className="max-w-[200px] lg:max-w-xs" src={image} alt={name} />
          </div>
          {/* Text */}
          <div className="flex-1 text-center lg:text-left">
            <h1 className="text-[26px] font-medium mb-2 max-w-[450px] mx-auto lg:mx-0">
              {name}
            </h1>
            <div className="text-2xl text-red-500 font-medium mb-6">
              $ {price}
            </div>
            <p className="mb-8">{name}</p>
            <button
              onClick={() =>
                addToCart(
                  { ...product, amount: 1, name: product.name },
                  product.id
                )
              }
              className="bg-primary py-4 px-8 text-white"
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
