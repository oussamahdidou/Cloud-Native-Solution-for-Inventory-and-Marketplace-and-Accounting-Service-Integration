package com.api.stockservice.domain.Repositories;

import com.api.stockservice.domain.Entities.Product;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ProductRepository extends JpaRepository<Product, Long> {
}
