package com.api.stockservice.infrastructure.messaging;

import com.api.stockservice.domain.event.RequestMessage;
import com.api.stockservice.domain.event.ResponseMessage;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class RequesterService {

    @Autowired
    private RabbitTemplate rabbitTemplate;


    public ResponseMessage sendRequest(String payload) {
        // Create the request message
        RequestMessage requestMessage = new RequestMessage();
        requestMessage.setPayload(payload);

        // Send the request and wait for a response
        ResponseMessage response = (ResponseMessage) rabbitTemplate.convertSendAndReceive(
                "test-request-queue",   // Queue name to send the message
                requestMessage        // Message payload to send
        );

        // Handle the response
        if (response != null) {
            System.out.println("Received response: " + response.getResult());
            return response;
        } else {
            System.out.println("No response received");
            return null;
        }
    }
}

