package com.api.stockservice.presentation.controller;

import org.springframework.beans.factory.annotation.Autowired;
// MessageController.java
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import com.api.stockservice.domain.event.SimpleMessage;
import com.api.stockservice.infrastructure.messaging.RabbitMQSender;

@RestController
public class MessageController {
    @Autowired
    private final RabbitMQSender rabbitMQSender;

    public MessageController(RabbitMQSender rabbitMQSender) {
        this.rabbitMQSender = rabbitMQSender;
    }

    @GetMapping("/send-message")
    public String sendMessage() {
        SimpleMessage message = new SimpleMessage("Hello from Spring Boot!");
        rabbitMQSender.send("stock_queue", message);
        return "Message Sent!";
    }
}
