package com.api.stockservice.domain.IServices;

import com.api.stockservice.application.DTOs.CategoryDto;
import com.api.stockservice.application.DTOs.createCategoryDTO;
import com.api.stockservice.domain.Entities.Category;

import java.util.List;

public interface ICategoryService {

    Category CreateCategory(CategoryDto categoryDto);
    Category GetCategory(String Id);
    List<Category> GetAllCategory();
    Category UpdateCategory(String id, CategoryDto categoryDto);
    boolean DeleteCategory(String ID);
}
