package com.api.stockservice.domain.IServices;

import com.api.stockservice.application.DTOs.ProductCreateDto;
import com.api.stockservice.application.DTOs.ProductDto;
import com.api.stockservice.domain.Entities.Product;

import java.util.List;

public interface IProductService {

     Product addProduct(ProductDto productDto);
     Product UpdateProduct(String ProductId,ProductDto productDto);
     Product getproduct(String ProductID);
     List<Product> getALLProduct();
     boolean DeleteProduct(String ProductId);
}
