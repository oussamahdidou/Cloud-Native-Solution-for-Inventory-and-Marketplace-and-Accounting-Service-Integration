import React, { useContext } from "react";
import { ProductContext } from "../Contexts/ProductContext";
import Product from "../components/Product";
import Hero from "../components/Hero";
import Header from "../components/Header";
import Sidebar from "../components/Sidebar";

const Home = () => {
  // get products from product context
  const { products } = useContext(ProductContext) || { products: [] };

  console.log(products);

  // get only men's and women's clothing category
  const filteredProducts = products.filter((item) => {
    return (
      item.category === "men's clothing" ||
      item.category === "women's clothing" ||
      item.category === "jewelery"
    );
  });

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
            {filteredProducts.map((product) => {
              return (
                <Product
                  key={product.id}
                  id={product.id}
                  name={product.name}
                  price={product.price}
                  amount={product.amount}
                  image={product.image}
                  category={product.category}
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
