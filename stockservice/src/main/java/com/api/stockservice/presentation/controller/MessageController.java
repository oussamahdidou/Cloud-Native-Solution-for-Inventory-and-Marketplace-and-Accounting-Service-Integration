package com.api.stockservice.presentation.controller;

import org.springframework.beans.factory.annotation.Autowired;

import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import com.api.stockservice.domain.event.SimpleMessage;
import com.api.stockservice.infrastructure.messaging.RabbitMQSender;

import java.util.Date;

@RestController
public class MessageController {
    @Autowired
    private final RabbitMQSender rabbitMQSender;
    public MessageController(RabbitMQSender rabbitMQSender) {
        this.rabbitMQSender = rabbitMQSender;
    }
    @GetMapping("/send-message")
    public String sendMessage() {
        //this is the producer consumer pattern
        Authentication authentication = SecurityContextHolder.getContext().getAuthentication();
        SimpleMessage message = new SimpleMessage();
        message.setText(authentication.getName());
        rabbitMQSender.send(message);
        return "Message Sent!";
    }
    @GetMapping("/date")
    public Date date(){
        return  new Date();
    }
}
