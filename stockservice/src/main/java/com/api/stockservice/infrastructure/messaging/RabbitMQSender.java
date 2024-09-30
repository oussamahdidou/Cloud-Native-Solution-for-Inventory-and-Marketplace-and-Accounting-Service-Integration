package com.api.stockservice.infrastructure.messaging;

// RabbitMQSender.java
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.api.stockservice.domain.event.SimpleMessage;

@Service
public class RabbitMQSender {
    @Autowired
    private final RabbitTemplate rabbitTemplate;

    public RabbitMQSender(RabbitTemplate rabbitTemplate) {
        this.rabbitTemplate = rabbitTemplate;
    }

    public void send(String queueName, SimpleMessage message) {
        rabbitTemplate.convertAndSend(queueName, message);
    }
}
