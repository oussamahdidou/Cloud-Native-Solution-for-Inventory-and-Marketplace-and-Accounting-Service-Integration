package com.api.stockservice.domain.IServices;

import com.api.stockservice.application.DTOs.CategoryDto;
import com.api.stockservice.application.DTOs.createCategoryDTO;
import com.api.stockservice.domain.Entities.Category;

import java.util.List;

public interface ICategoryService {

    createCategoryDTO CreateCategory(CategoryDto categoryDto);
    createCategoryDTO GetCategory(String Id);
    List<createCategoryDTO> GetAllCategory();
    createCategoryDTO UpdateCategory(String id, CategoryDto categoryDto);
    boolean DeleteCategory(String ID);
}
