import React, { useContext, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { CartContext } from "../Contexts/CartContext";
import { ProductDetail } from "../models/ProductModels";
import { GetProductDetail, GetProducts } from "../Services/ProductsService";

const ProductDetails: React.FC = () => {
  // Get the product id from URL
  const { id } = useParams<{ id: string }>();
  const [product, setProduct] = useState<ProductDetail>();
  useEffect(() => {
    const GetProductDetails = async (id: string) => {
      const result = await GetProductDetail(id);
      setProduct(result);
    };
    GetProductDetails(id || "");
  }, []);

  return (
    <section className="pt-[450px] md:pt-32 pb-[400px] md:pb-12 lg:py-32 h-screen flex items-center">
      <div className="container mx-auto">
        {/* Image and text wrapper */}
        <div className="flex flex-col lg:flex-row items-center gap-4">
          {/* Image */}
          <div className="flex flex-1 justify-center items-center mb-8 lg:mb-0">
            <img className="w-full aspect-square" src={product?.thumbnail} />
          </div>
          {/* Text */}
          <div className="flex-1 text-center lg:text-left">
            <h1 className="text-[26px] text-4xl font-medium mb-2 max-w-[450px] mx-auto lg:mx-0">
              {product?.name}
            </h1>
            <div className="text-2xl text-red-500 font-medium mb-6">
              $ {product?.price}
            </div>
            <p className="mb-8">{product?.description}</p>
            <div className="flex  items-center gap-5">
              <div>
                <img
                  className="aspect-square w-12 rounded-full "
                  src={product?.categoryThumbnail}
                  alt=""
                />
                <p className="mb-8 text-center">{product?.categoryName}</p>
              </div>

              <div>
                <img
                  className="aspect-square w-12 rounded-full "
                  src={product?.marqueIcon}
                  alt=""
                />
                <p className="mb-8 text-center">{product?.marqueName}</p>
              </div>
            </div>
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
