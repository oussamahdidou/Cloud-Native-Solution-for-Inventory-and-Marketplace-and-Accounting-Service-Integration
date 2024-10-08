package com.api.stockservice.infrastructure.messaging;

import com.api.stockservice.domain.event.MyEvent;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class MyEventPublisher {

    private final RabbitTemplate rabbitTemplate;

    @Autowired
    public MyEventPublisher(RabbitTemplate rabbitTemplate) {
        this.rabbitTemplate = rabbitTemplate;
    }

    public void publishEvent(String value) {
        MyEvent event = new MyEvent();
        event.setValue(value);

        // Publish to the fanout exchange
        rabbitTemplate.convertAndSend("publish_exchange", "", event); // No routing key needed for fanout exchange
        System.out.println("Published event: " + value);
    }
}