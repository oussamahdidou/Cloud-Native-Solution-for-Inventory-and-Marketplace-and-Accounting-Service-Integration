package com.api.stockservice.presentation.controller;

import com.api.stockservice.application.DTOs.CategoryDto;
import com.api.stockservice.domain.Entities.Category;
import com.api.stockservice.domain.IServices.ICategoryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api/category")
public class CategoryController {


    @Autowired
    private ICategoryService categoryService;

    @PostMapping()
    public Category addedCategory(@RequestBody CategoryDto categoryDto)
    {
        return categoryService.CreateCategory(categoryDto);
    }


}
