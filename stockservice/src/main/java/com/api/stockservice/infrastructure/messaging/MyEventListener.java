package com.api.stockservice.infrastructure.messaging;

import com.api.stockservice.domain.event.MyEvent;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.messaging.handler.annotation.Payload;
import org.springframework.stereotype.Component;

@Component
public class MyEventListener {

    @RabbitListener(queues = "spring-boot-queue")
    public void receiveMessage(@Payload MyEvent event) {
        System.out.println("Received message: " + event.getValue());
        // Process the message
    }
}
