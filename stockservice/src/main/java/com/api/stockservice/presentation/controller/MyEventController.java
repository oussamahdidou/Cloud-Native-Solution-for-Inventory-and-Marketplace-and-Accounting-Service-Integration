package com.api.stockservice.presentation.controller;

import com.api.stockservice.infrastructure.messaging.MyEventPublisher;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.RestTemplate;

@RestController
public class MyEventController {

    private final MyEventPublisher myEventPublisher;
    private final RestTemplate restTemplate;
    @Autowired
    public MyEventController(MyEventPublisher myEventPublisher, RestTemplate restTemplate) {
        this.myEventPublisher = myEventPublisher;
        this.restTemplate = restTemplate;

    }

    @PostMapping("/publish")
    public String publishEvent(@RequestBody String value) {
        myEventPublisher.publishEvent(value);
        return "Event published successfully!";
    }
    @PostMapping("/send-message")
    public ResponseEntity<String> getUserId() {

        return ResponseEntity.ok("wjh zft");
    }
}