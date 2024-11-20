package com.api.stockservice.infrastructure.messaging;

import com.api.stockservice.application.DTOs.SupplierDto;
import com.api.stockservice.domain.Repositories.ISupplierPublisher;
import com.api.stockservice.domain.event.SupplierEvents.SupplierAddedEvent;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class SupplierPublisher implements ISupplierPublisher {

    private String exchange = "Supplier-added-Exchange";
    private RabbitTemplate rabbitTemplate;

    @Autowired
    public SupplierPublisher (RabbitTemplate rabbitTemplate)
    {
        this.rabbitTemplate = rabbitTemplate;
    }
    @Override
    public void SendSupplier(SupplierAddedEvent supplierAddedEvent)
    {
        rabbitTemplate.convertAndSend(exchange,"",supplierAddedEvent);
    }
}
