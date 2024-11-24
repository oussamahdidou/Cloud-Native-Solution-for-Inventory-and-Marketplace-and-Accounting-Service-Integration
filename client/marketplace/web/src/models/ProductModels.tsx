export interface ProductItem {
  productId: string;
  name: string;
  price: number;
  thumbnail: string;
  quantity: number;
}
export interface ProductDetail {
  productId: string;
  marqueName: string;
  marqueIcon: string;
  name: string;
  description: string;
  price: number;
  quantity: number;
  thumbnail: string;
  categoryId: string;
  categoryThumbnail: string;
  categoryName: string;
}
