import React, { useContext, useEffect, useState } from "react";
import Product from "../components/Product";
import Hero from "../components/Hero";
import Header from "../components/Header";
import Sidebar from "../components/Sidebar";
import { GetProducts } from "../Services/ProductsService";
import { ProductItem } from "../models/ProductModels";

const Home = () => {
  const [products, setProducts] = useState<ProductItem[]>([]);

  useEffect(() => {
    const GetProductsItems = async () => {
      const result = await GetProducts();
      setProducts(result);
    };
    GetProductsItems();
  }, []);
  return (
    <div>
      <Header></Header>
      <Sidebar></Sidebar>
      <Hero />
      <section className="py-20">
        <div className="container mx-auto">
          <h1 className="text-3xl font-semibold mb-10 text-center">
            Explore Our Products
          </h1>
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-5 lg:mx-8 gap-[30px] max-w-sm mx-auto md:max-w-none md:mx-0">
            {products.map((product) => {
              return (
                <Product
                  key={product.productId}
                  productId={product.productId}
                  name={product.name}
                  price={product.price}
                  quantity={product.quantity}
                  thumbnail={product.thumbnail}
                />
              );
            })}
          </div>
        </div>
      </section>
    </div>
  );
};

export default Home;
//
