package com.api.stockservice.domain.Repositories;

import com.api.stockservice.application.DTOs.ProductDto;
import com.api.stockservice.domain.Entities.Product;
import org.springframework.data.jpa.repository.JpaRepository;
import java.util.List;

public interface ProductRepository extends JpaRepository<Product, String> {
//    List<Product> FindByCategory(String Category);
}
