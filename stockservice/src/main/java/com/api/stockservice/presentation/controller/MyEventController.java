package com.api.stockservice.presentation.controller;

import com.api.stockservice.infrastructure.messaging.MyEventPublisher;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class MyEventController {

    private final MyEventPublisher myEventPublisher;

    @Autowired
    public MyEventController(MyEventPublisher myEventPublisher) {
        this.myEventPublisher = myEventPublisher;
    }

    @PostMapping("/publish")
    public String publishEvent(@RequestBody String value) {
        myEventPublisher.publishEvent(value);
        return "Event published successfully!";
    }
}