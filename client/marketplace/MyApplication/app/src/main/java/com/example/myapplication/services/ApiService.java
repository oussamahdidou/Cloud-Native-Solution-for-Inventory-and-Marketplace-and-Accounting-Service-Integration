package com.example.myapplication.services;

import com.example.myapplication.models.CategoryItem;
import com.example.myapplication.models.ProductItem;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

public interface ApiService {
    @GET("api/Category/GetCategories") // Replace "categories" with your actual endpoint
    Call<List<CategoryItem>> getCategories();
    @GET("api/Product/GetProducts")
    Call<List<ProductItem>> getProducts();

}
