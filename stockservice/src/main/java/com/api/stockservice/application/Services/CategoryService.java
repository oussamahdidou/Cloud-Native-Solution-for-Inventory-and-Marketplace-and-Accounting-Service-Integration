package com.api.stockservice.application.Services;

import com.api.stockservice.application.DTOs.CategoryDto;
import com.api.stockservice.application.DTOs.ProductDto;
import com.api.stockservice.application.DTOs.createCategoryDTO;
import com.api.stockservice.domain.Entities.Category;
import com.api.stockservice.domain.IServices.ICategoryService;
import com.api.stockservice.domain.Repositories.CategoryRepository;
import com.api.stockservice.domain.Repositories.ICategoryPublisher;
import com.api.stockservice.domain.event.CategoryEvents.AddedCategoryEvent;
import com.cloudinary.Url;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;
import java.io.IOException;


@Service
public class CategoryService implements ICategoryService {

    private final CategoryRepository categoryRepository;
    private final ICategoryPublisher categoryPublisher;
    private final CloudinaryService cloudinaryService;

    @Autowired
    public CategoryService(CategoryRepository categoryRepository, ICategoryPublisher categoryPublisher, CloudinaryService cloudinaryService)
    {
        this.categoryRepository = categoryRepository;
        this.categoryPublisher = categoryPublisher;
        this.cloudinaryService = cloudinaryService;
    }

    @Override
    public createCategoryDTO CreateCategory(CategoryDto categoryDto)
    {
        Category category = new Category();
        category.setName(categoryDto.getName());
        try {
            String urlThumbnail = cloudinaryService.UploadImage(categoryDto.getThumbnail());
            category.setThumbnail(urlThumbnail);

        } catch (IOException e) {
            throw new RuntimeException("Failed to upload image to Cloudinary", e);
        }
        Category savedCategory = categoryRepository.save(category);
        categoryPublisher.SendAddedCategroy(new AddedCategoryEvent(savedCategory.getId(),savedCategory.getName(),savedCategory.getThumbnail()));
        return toDTO(savedCategory);
    }
    @Override
    public createCategoryDTO UpdateCategory(String  id , CategoryDto categoryDto)
    {
        Category category = categoryRepository.findById(id).orElseThrow();
        if (categoryDto.getName() != null) category.setName(categoryDto.getName());
        if(categoryDto.getThumbnail()  != null)
        {
            try{
                String UrlThumbnail = cloudinaryService.UploadImage(categoryDto.getThumbnail());
                category.setThumbnail(UrlThumbnail);
            }catch(IOException e){
                throw new RuntimeException("Failed to upload image to Cloudinary", e);
            }
        }
        return toDTO(categoryRepository.save(category));
    }
    public createCategoryDTO GetCategory(String id)
    {
        Category category = categoryRepository.findById(id).orElseThrow();
        return toDTO(category);
    }
    public createCategoryDTO toDTO(Category category)
    {
        return new createCategoryDTO(category.getName(),category.getThumbnail());
    }
    public List<createCategoryDTO> GetAllCategory()
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
