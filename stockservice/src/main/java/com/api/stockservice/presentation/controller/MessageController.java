package com.api.stockservice.presentation.controller;

import com.api.stockservice.domain.event.UserIdResponse;
import com.api.stockservice.infrastructure.messaging.GetUserIdSender;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Autowired;

import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import com.api.stockservice.domain.event.SimpleMessage;

import java.util.Date;

@RestController
public class MessageController {
    @Autowired
    private GetUserIdSender getUserIdSender;

    public MessageController(GetUserIdSender getUserIdSender) {
        this.getUserIdSender = getUserIdSender;
    }

    @GetMapping("/send-message")
    public String sendMessage() {
        //this is the producer consumer pattern
        Authentication authentication = SecurityContextHolder.getContext().getAuthentication();
        SimpleMessage message = new SimpleMessage();
        message.setText(authentication.getName());
        // Send the message to "getuserexchange"
       getUserIdSender.sendMessageAndReceiveResponse(authentication.getName());

        return "";
    }

}
