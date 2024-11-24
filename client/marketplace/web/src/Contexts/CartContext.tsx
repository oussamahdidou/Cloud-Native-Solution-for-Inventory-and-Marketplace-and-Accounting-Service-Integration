import React, {
  createContext,
  useState,
  useEffect,
  ReactNode,
  useContext,
} from "react";
import { Cart, CartItem } from "../models/CartModels";
import { GetCart } from "../Services/CartService";

interface CartContextType {
  cart: Cart | null;
  addToCart: (product: CartItem) => void;
  removeFromCart: (productId: string) => void;
  clearCart: () => void;
  increaseAmount: (productId: string) => void;
  decreaseAmount: (productId: string) => void;
  checkItemInCart: (productId: string) => boolean;
}

export const CartContext = createContext<CartContextType>(
  {} as CartContextType
);

interface CartProviderProps {
  children: ReactNode;
}

const CartProvider: React.FC<CartProviderProps> = ({ children }) => {
  const [cart, setCart] = useState<Cart | null>(null);

  // Fetch cart data when the provider is mounted
  useEffect(() => {
    const fetchCart = async () => {
      try {
        const cartData = await GetCart();
        setCart(cartData);
      } catch (error) {
        console.error("Failed to fetch cart:", error);
      }
    };

    fetchCart();
  }, []);

  // Update totalAmount whenever cartItems change
  useEffect(() => {
    if (cart) {
      const total = cart.cartItems.reduce(
        (accumulator, item) => accumulator + item.totalAmount,
        0
      );
      setCart((prevCart) =>
        prevCart ? { ...prevCart, totalAmount: total } : null
      );
    }
  }, [cart?.cartItems]);

  // Add item to cart
  const addToCart = (product: CartItem) => {
    if (!cart) return;

    const existingItem = cart.cartItems.find(
      (item) => item.productId === product.productId
    );

    if (existingItem) {
      const updatedItems = cart.cartItems.map((item) =>
        item.productId === product.productId
          ? {
              ...item,
              quantity: item.quantity + 1,
              totalAmount: (item.quantity + 1) * item.unityPrice,
            }
          : item
      );
      setCart({ ...cart, cartItems: updatedItems });
    } else {
      const newItem = {
        ...product,
        quantity: 1,
        totalAmount: product.unityPrice,
      };
      setCart({ ...cart, cartItems: [...cart.cartItems, newItem] });
    }
  };

  // Remove item from cart
  const removeFromCart = (productId: string) => {
    if (!cart) return;

    const updatedItems = cart.cartItems.filter(
      (item) => item.productId !== productId
    );
    setCart({ ...cart, cartItems: updatedItems });
  };

  // Clear the cart
  const clearCart = () => {
    if (!cart) return;

    setCart({ ...cart, cartItems: [] });
  };

  // Increase item quantity
  const increaseAmount = (productId: string) => {
    if (!cart) return;

    const existingItem = cart.cartItems.find(
      (item) => item.productId === productId
    );
    if (existingItem) {
      addToCart(existingItem);
    }
  };

  // Decrease item quantity
  const decreaseAmount = (productId: string) => {
    if (!cart) return;

    const existingItem = cart.cartItems.find(
      (item) => item.productId === productId
    );

    if (existingItem) {
      if (existingItem.quantity > 1) {
        const updatedItems = cart.cartItems.map((item) =>
          item.productId === productId
            ? {
                ...item,
                quantity: item.quantity - 1,
                totalAmount: (item.quantity - 1) * item.unityPrice,
              }
            : item
        );
        setCart({ ...cart, cartItems: updatedItems });
      } else {
        removeFromCart(productId);
      }
    }
  };

  // Check if an item exists in the cart
  const checkItemInCart = (productId: string): boolean => {
    if (!cart) return false;
    return cart.cartItems.some((item) => item.productId === productId);
  };

  return (
    <CartContext.Provider
      value={{
        cart,
        addToCart,
        removeFromCart,
        clearCart,
        increaseAmount,
        decreaseAmount,
        checkItemInCart,
      }}
    >
      {children}
    </CartContext.Provider>
  );
};

export default CartProvider;
