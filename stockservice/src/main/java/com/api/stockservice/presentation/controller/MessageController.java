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
        Authentication authentication = SecurityContextHolder.getContext().getAuthentication();

        // If user details are implemented
//        if (authentication.getPrincipal() instanceof UserDetails) {
//            UserDetails userDetails = (UserDetails) authentication.getPrincipal();
//            return userDetails.getUsername(); // This returns the username
//        }

        // For other cases
        return authentication.getName();
//        SimpleMessage message = new SimpleMessage();
//        message.setText("hello i`m springboot");
//        rabbitMQSender.send(message);
//
//        return "Message Sent!";
    }
    @GetMapping("/date")
    public Date date(){
        return  new Date();
    }
}
