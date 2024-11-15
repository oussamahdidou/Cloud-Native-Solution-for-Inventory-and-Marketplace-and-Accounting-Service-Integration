package com.api.stockservice.application.Services;

import com.api.stockservice.application.DTOs.CategoryDto;
import com.api.stockservice.application.DTOs.ProductDto;
import com.api.stockservice.domain.Entities.Category;
import com.api.stockservice.domain.IServices.ICategoryService;
import com.api.stockservice.domain.Repositories.CategoryRepository;
import com.api.stockservice.domain.Repositories.ICategoryPublisher;
import com.api.stockservice.domain.event.CategoryEvents.AddedCategoryEvent;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class CategoryService implements ICategoryService {

    private final CategoryRepository categoryRepository;
    private final ICategoryPublisher categoryPublisher;
    @Autowired
    public CategoryService(CategoryRepository categoryRepository, ICategoryPublisher categoryPublisher)
    {
        this.categoryRepository = categoryRepository;
        this.categoryPublisher = categoryPublisher;
    }

    @Override
    public Category CreateCategory(CategoryDto categoryDto)
    {
        Category category = new Category();
        category.setName(categoryDto.getName());
        category.setThumbnail(categoryDto.getThumbnail());
        Category savedCategory = categoryRepository.save(category);
        System.out.println(savedCategory);
        categoryPublisher.SendAddedCategroy(new AddedCategoryEvent(savedCategory.getId(),savedCategory.getName(),savedCategory.getThumbnail()));
        return savedCategory;
    }
    @Override
    public Category UpdateCategory(String  id , CategoryDto categoryDto)
    {
        Category category = categoryRepository.findById(id).orElseThrow();
        if (categoryDto.getName() != null) category.setName(categoryDto.getName());
        if(categoryDto.getThumbnail() != null) category.setThumbnail(categoryDto.getThumbnail());
        return categoryRepository.save(category);
    }
    public CategoryDto GetAllCategory(String id)
    {
        Category category = categoryRepository.findById(id).orElseThrow();
        return toDTO(category);
    }
    public CategoryDto toDTO(Category category)
    {
        return new CategoryDto(category.getName(),category.getThumbnail());
    }
    public List<CategoryDto> GetAllCategory()
    {
        List<Category> ListOfCategory = categoryRepository.findAll();
        return ListOfCategory.stream().map(this::toDTO).collect(Collectors.toList());
    }
    public boolean DeleteCategory(String ID)
    {
        if(categoryRepository.existsById(ID))
        {
            categoryRepository.deleteById(ID);
            return true;
        }else{
            throw new EntityNotFoundException("this  cotegory with this id" + ID + "not found");
        }
    }

}
