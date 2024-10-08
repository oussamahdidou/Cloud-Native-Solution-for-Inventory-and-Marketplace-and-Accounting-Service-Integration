package com.api.stockservice.presentation.controller;

import com.api.stockservice.domain.event.ResponseMessage;
import com.api.stockservice.infrastructure.messaging.MyEventPublisher;
import com.api.stockservice.infrastructure.messaging.RequesterService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
public class MyEventController {

    private final MyEventPublisher myEventPublisher;

    private final RequesterService requesterService;
    @Autowired
    public MyEventController(MyEventPublisher myEventPublisher, RequesterService requesterService) {
        this.myEventPublisher = myEventPublisher;
        this.requesterService = requesterService;
    }

    @PostMapping("/publish")
    public String publishEvent(@RequestBody String value) {
        myEventPublisher.publishEvent(value);
        return "Event published successfully!";
    }
    @GetMapping("/send-request")
    public ResponseMessage sendRequest(@RequestParam String message) {
        // Send the request and return the response
        return requesterService.sendRequest(message);
    }
}