package com.api.stockservice.infrastructure.messaging;

import com.api.stockservice.application.DTOs.ProductDto;
import com.api.stockservice.domain.Repositories.IProductPublisher;
import com.api.stockservice.domain.Entities.Product;
import com.api.stockservice.domain.event.EntreeEvents.EntreeRecordedEvent;
import com.api.stockservice.domain.event.PoductEvents.ProductAddedEvent;
import com.api.stockservice.domain.event.PoductEvents.ProductDeleteEvent;
import com.api.stockservice.domain.event.PoductEvents.UpdateProductEvent;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ProductPublisher implements IProductPublisher {
    private final RabbitTemplate rabbitTemplate;
    private final String exchange = "product-exchange";
    private final String exchnage2= "product-Update-exchange";
    private String DeleteExchange = "product-Delete-exchange" ;

    @Autowired
    public ProductPublisher(RabbitTemplate rabbitTemplate) {
        this.rabbitTemplate = rabbitTemplate;
    }


    @Override
    public void sendProductAddedEvent(ProductAddedEvent productAddedEvent) {
        rabbitTemplate.convertAndSend(exchange, "", productAddedEvent);

    }
    @Override
    public void sendUpadatedProduct(UpdateProductEvent updateProductEvent)
    {
        rabbitTemplate.convertAndSend(exchnage2,"",updateProductEvent);
    }
    @Override
    public void sendIdProduct(ProductDeleteEvent productDeleteEvent)
    {
        rabbitTemplate.convertAndSend(DeleteExchange,"",productDeleteEvent);
    }

    @Override
    public void recordproductentree(EntreeRecordedEvent entreeRecordedEvent) {
        rabbitTemplate.convertAndSend("product-entree-exchange","",entreeRecordedEvent);

    }
}
