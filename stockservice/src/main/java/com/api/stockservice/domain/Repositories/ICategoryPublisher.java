package com.api.stockservice.domain.Repositories;

import com.api.stockservice.application.DTOs.CategoryDto;
import com.api.stockservice.domain.event.CategoryEvents.AddedCategoryEvent;

public interface ICategoryPublisher {
    void SendAddedCategroy(AddedCategoryEvent addedCategoryEvent);
}
