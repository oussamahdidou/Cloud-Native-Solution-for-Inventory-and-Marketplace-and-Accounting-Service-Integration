package com.api.stockservice.infrastructure.messaging;

import com.api.stockservice.domain.event.SimpleMessage;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.stereotype.Component;
import org.springframework.amqp.core.Message;
@Component
public class RabbitMQListener {

    @RabbitListener(queues = "receive_queue")
    public void listen(SimpleMessage message) {
        System.out.println("Received message: " + message.getText());
    }  }