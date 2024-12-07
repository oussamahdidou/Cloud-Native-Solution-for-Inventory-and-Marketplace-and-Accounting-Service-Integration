package com.api.stockservice.presentation.controller;

import com.api.stockservice.application.DTOs.CategoryDto;
import com.api.stockservice.application.DTOs.SupplierDto;
import com.api.stockservice.application.DTOs.createCategoryDTO;
import com.api.stockservice.application.Services.CategoryService;
import com.api.stockservice.application.Services.CloudinaryService;
import com.api.stockservice.domain.Entities.Category;
import com.api.stockservice.domain.IServices.ICategoryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;
import java.util.List;

@RestController
@RequestMapping("/api/category")
public class CategoryController {

    private ICategoryService categoryService;
    private CloudinaryService cloudinaryService;

    @Autowired
    public CategoryController (ICategoryService categoryService, CloudinaryService cloudinaryService)
    {
        this.categoryService = categoryService;
        this.cloudinaryService = cloudinaryService;
    }

    @PostMapping(consumes = MediaType.MULTIPART_FORM_DATA_VALUE)
    public Category addedCategory(@ModelAttribute CategoryDto categoryDto)
    {
        return categoryService.CreateCategory(categoryDto);
    }

    @GetMapping("/Categories")
    public List<Category> GetAllCategory()
    {
        return categoryService.GetAllCategory();
    }

    @GetMapping("/{IdCategory}")
    public Category GetCategory(@PathVariable String IdCategory)
    {
        return categoryService.GetCategory(IdCategory);
    }

    @PutMapping(path= "/{IdCategory}" ,consumes = MediaType.MULTIPART_FORM_DATA_VALUE)
    public Category UpdateCategory(@PathVariable String IdCategory, @ModelAttribute CategoryDto categoryDto)
    {
        return categoryService.UpdateCategory(IdCategory,categoryDto);
    }
    @DeleteMapping("{IdCategory}")
    public boolean DeleteCategory(String IdCategory)
    {
        return categoryService.DeleteCategory(IdCategory);
    }

}
