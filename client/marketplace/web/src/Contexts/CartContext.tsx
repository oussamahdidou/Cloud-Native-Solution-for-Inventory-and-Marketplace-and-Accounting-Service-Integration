import React, {
  createContext,
  useState,
  useEffect,
  ReactNode,
  useContext,
} from "react";
import { Cart, CartItem } from "../models/CartModels";
import {
  AddProductToCart,
  CheckoutCart,
  DecreaseProductQuantity,
  GetCart,
  IncreaseProductQuantity,
  RemoveProductFromCart,
} from "../Services/CartService";
import { useAuth } from "./useAuth";
import toast from "react-hot-toast";
import { createPaypal } from "../Services/PaypalService";

interface CartContextType {
  cart: Cart;
  addToCart: (product: CartItem) => void;
  removeFromCart: (productId: string) => void;
  clearCart: () => void;
  decreaseAmount: (productId: string) => void;
  checkItemInCart: (productId: string) => boolean;
  checkout: () => void;
}

export const CartContext = createContext<CartContextType>(
  {} as CartContextType
);

interface CartProviderProps {
  children: ReactNode;
}

const CartProvider: React.FC<CartProviderProps> = ({ children }) => {
  const { isLoggedIn } = useAuth();
  const [cart, setCart] = useState<Cart>({
    cartId: 0,
    cartItems: [],
    totalAmount: 0,
  });

  useEffect(() => {
    const fetchCart = async () => {
      try {
        if (!isLoggedIn) {
          console.error("User is not logged in. Cannot add product to cart.");
          return;
        }
        const cartData = await GetCart();
        updateCartTotal(cartData);
      } catch (error) {
        console.error("Failed to fetch cart:", error);
      }
    };

    fetchCart();
  }, []);

  // Helper function to update the cart's total amount
  const updateCartTotal = (updatedCart: Cart | null) => {
    if (!isLoggedIn) {
      console.error("User is not logged in. Cannot add product to cart.");
      return;
    }
    if (!updatedCart) return;
    const total = updatedCart.cartItems.reduce(
      (sum, item) => sum + item.totalAmount,
      0
    );
    setCart({ ...updatedCart, totalAmount: total });
  };

  const addToCart = async (product: CartItem) => {
    if (!isLoggedIn) {
      console.error("User is not logged in. Cannot add product to cart.");
      return;
    }
    if (!cart) return;

    const existingItem = cart.cartItems.find(
      (item) => item.productId === product.productId
    );

    try {
      if (existingItem) {
        await IncreaseProductQuantity(product.productId, cart.cartId);

        const updatedItems = cart.cartItems.map((item) =>
          item.productId === product.productId
            ? {
                ...item,
                quantity: item.quantity + 1,
                totalAmount: (item.quantity + 1) * item.unityPrice,
              }
            : item
        );
        updateCartTotal({ ...cart, cartItems: updatedItems });
      } else {
        await AddProductToCart(product.productId, cart.cartId);

        const newItem = {
          ...product,
          quantity: 1,
          totalAmount: product.unityPrice,
        };
        updateCartTotal({ ...cart, cartItems: [...cart.cartItems, newItem] });
      }
    } catch (error) {
      console.error("Failed to add product to cart:", error);
    }
  };

  const decreaseAmount = async (productId: string) => {
    if (!isLoggedIn) {
      console.error("User is not logged in. Cannot add product to cart.");
      return;
    }
    if (!cart) return;

    const existingItem = cart.cartItems.find(
      (item) => item.productId === productId
    );

    if (!existingItem) return;

    try {
      if (existingItem.quantity === 1) {
        await RemoveProductFromCart(productId, cart.cartId);

        const updatedItems = cart.cartItems.filter(
          (item) => item.productId !== productId
        );
        updateCartTotal({ ...cart, cartItems: updatedItems });
      } else {
        await DecreaseProductQuantity(productId, cart.cartId);

        const updatedItems = cart.cartItems.map((item) =>
          item.productId === productId
            ? {
                ...item,
                quantity: item.quantity - 1,
                totalAmount: (item.quantity - 1) * item.unityPrice,
              }
            : item
        );
        updateCartTotal({ ...cart, cartItems: updatedItems });
      }
    } catch (error) {
      console.error("Failed to decrease product quantity:", error);
    }
  };

  const clearCart = async () => {
    if (!isLoggedIn) {
      console.error("User is not logged in. Cannot add product to cart.");
      return;
    }
    if (!cart) return;

    try {
      for (const item of cart.cartItems) {
        await RemoveProductFromCart(item.productId, cart.cartId);
      }
      updateCartTotal({ ...cart, cartItems: [] });
    } catch (error) {
      console.error("Failed to clear cart:", error);
    }
  };

  const removeFromCart = async (productId: string) => {
    if (!isLoggedIn) {
      console.error("User is not logged in. Cannot add product to cart.");
      return;
    }
    if (!cart) return;

    try {
      await RemoveProductFromCart(productId, cart.cartId);

      const updatedItems = cart.cartItems.filter(
        (item) => item.productId !== productId
      );
      updateCartTotal({ ...cart, cartItems: updatedItems });
    } catch (error) {
      console.error("Failed to remove product from cart:", error);
    }
  };

  const checkItemInCart = (productId: string): boolean => {
    if (!cart) return false;
    return cart.cartItems.some((item) => item.productId === productId);
  };
  const checkout = async () => {
    if (!isLoggedIn) {
      console.error("User is not logged in. Cannot add product to cart.");
      toast.error("You must be logged in to checkout!");

      return;
    }

    if (!cart) {
      toast.error("Your cart is empty!");
      return;
    }

    toast.loading("Processing checkout...");
    try {
      const checkout = await CheckoutCart();
      console.log(checkout);
      const link = await createPaypal(
        checkout.commandeId,
        checkout.totaleAmount
      );
      toast.success("Checkout successful!");
      setCart({ cartId: cart.cartId, cartItems: [], totalAmount: 0 });

      window.location.href = link;
    } catch (error) {
      console.error(error);
      toast.error("Something went wrong during checkout.");
    }
  };
  return (
    <CartContext.Provider
      value={{
        checkout,
        cart,
        addToCart,
        removeFromCart,
        clearCart,
        decreaseAmount,
        checkItemInCart,
      }}
    >
      {children}
    </CartContext.Provider>
  );
};

export default CartProvider;
