package com.api.stockservice.domain.Repositories;

import com.api.stockservice.domain.Entities.Category;
import org.springframework.data.jpa.repository.JpaRepository;

public interface CategoryRepository extends JpaRepository<Category, String> {
}
