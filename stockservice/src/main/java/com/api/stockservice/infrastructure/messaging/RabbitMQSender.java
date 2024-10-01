package com.api.stockservice.infrastructure.messaging;

// RabbitMQSender.java
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import com.api.stockservice.domain.event.SimpleMessage;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;

@Service
public class RabbitMQSender {
    @Autowired
    private final RabbitTemplate rabbitTemplate;
    @Autowired
    private ObjectMapper objectMapper;

    public RabbitMQSender(RabbitTemplate rabbitTemplate, ObjectMapper objectMapper) {
        this.rabbitTemplate = rabbitTemplate;
        this.objectMapper = objectMapper;
    }

    public void send(SimpleMessage message) {


            // Send the JSON message to RabbitMQ
            rabbitTemplate.convertAndSend("stock_exchange", "stock", message);
            System.out.println(message);

    }
}
