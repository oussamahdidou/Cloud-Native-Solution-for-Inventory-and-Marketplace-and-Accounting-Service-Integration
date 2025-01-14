package com.api.stockservice.infrastructure.messaging;

import com.api.stockservice.application.DTOs.CategoryDto;
import com.api.stockservice.domain.Repositories.ICategoryPublisher;
import com.api.stockservice.domain.event.CategoryEvents.AddedCategoryEvent;
import com.api.stockservice.domain.event.CategoryEvents.DeleteCatgoryEvent;
import com.api.stockservice.domain.event.CategoryEvents.UpdateCategoryEvent;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CategoryPublisher implements ICategoryPublisher {

    private final RabbitTemplate rabbitTemplate;
    private final String Exchange = "Category-added-Exchange";
    private final String UpdateExchange = "Category-Update-Exchange";
    private final String DeleteExchange  = "Category-Delete-Exchange";

    @Autowired
    public CategoryPublisher(RabbitTemplate rabbitTemplate) {
        this.rabbitTemplate = rabbitTemplate;
    }


    @Override
    public void SendAddedCategroy(AddedCategoryEvent addedCategoryEvent)
    {
        rabbitTemplate.convertAndSend(Exchange,"",addedCategoryEvent);
    }
    @Override
    public void SendUpdateCategory(UpdateCategoryEvent updateCategoryEvent)
    {
        rabbitTemplate.convertAndSend(UpdateExchange,"",updateCategoryEvent);
    }
    @Override
    public void SendDeleteCategory(DeleteCatgoryEvent deleteCatgoryEvent)
    {
        rabbitTemplate.convertAndSend(DeleteExchange,"",deleteCatgoryEvent);
    }
}
