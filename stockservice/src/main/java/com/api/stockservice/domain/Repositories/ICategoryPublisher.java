package com.api.stockservice.domain.Repositories;

import com.api.stockservice.application.DTOs.CategoryDto;
import com.api.stockservice.domain.event.CategoryEvents.AddedCategoryEvent;
import com.api.stockservice.domain.event.CategoryEvents.DeleteCatgoryEvent;
import com.api.stockservice.domain.event.CategoryEvents.UpdateCategoryEvent;

public interface ICategoryPublisher {
    void SendAddedCategroy(AddedCategoryEvent addedCategoryEvent);
    void SendUpdateCategory(UpdateCategoryEvent updateCategoryEvent);
    void SendDeleteCategory(DeleteCatgoryEvent deleteCatgoryEvent);
}
