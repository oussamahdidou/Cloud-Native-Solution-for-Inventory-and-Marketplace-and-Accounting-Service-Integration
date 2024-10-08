package com.api.stockservice.infrastructure.messaging;

import com.api.stockservice.domain.event.RequestMessage;
import com.api.stockservice.domain.event.ResponseMessage;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.messaging.handler.annotation.Payload;
import org.springframework.stereotype.Component;

@Component
public class RequestListener {

    @Autowired
    private RabbitTemplate rabbitTemplate;

    @RabbitListener(queues = "my-request-queue")
    public ResponseMessage handleRequest(@Payload RequestMessage request) {
        // Process the request
        String result = "Processed: " + request.getPayload();

        // Create a response
        return new ResponseMessage(result);
    }
}
