package com.api.stockservice.presentation.controller;


import com.api.stockservice.application.DTOs.ProductCreateDto;
import com.api.stockservice.application.DTOs.ProductDto;
//import com.api.stockservice.application.Services.ProductService;
import com.api.stockservice.domain.Entities.Product;
import com.api.stockservice.domain.IServices.IProductService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.RestTemplate;

import java.util.List;

@RestController
@RequestMapping("/api/product")
public class    ProductController  {

    private  RestTemplate restTemplate;
    private  IProductService productService;

    @Autowired
    public ProductController(IProductService productService,RestTemplate restTemplate ) {

        this.restTemplate = restTemplate;
        this.productService = productService;
    }

    @PostMapping(consumes = MediaType.MULTIPART_FORM_DATA_VALUE)
    public Product addProduct(@ModelAttribute  ProductDto productDto) {
        return productService.addProduct(productDto);
    }

    @PutMapping(path="/{ProductId}", consumes = MediaType.MULTIPART_FORM_DATA_VALUE)
    public Product UpdateProduct(@PathVariable String ProductId, @ModelAttribute ProductDto productDto)
    {
        return productService.UpdateProduct(ProductId, productDto);
    }

    @GetMapping("/{ProductId}")
    public Product GetProduct(@PathVariable String ProductId)
    {
        return productService.getproduct(ProductId);
    }

    @GetMapping("/Products")
    public List<Product> GetAllProduct()
    {
        return productService.getALLProduct();
    }

    @DeleteMapping("/{ProductId}")
    public boolean DeleteProduct(@PathVariable String ProductId)
    {
        return productService.DeleteProduct(ProductId);
    }

}
