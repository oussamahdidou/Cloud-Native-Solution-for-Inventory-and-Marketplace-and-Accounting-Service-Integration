package com.api.stockservice.infrastructure.messaging;

import com.api.stockservice.domain.event.SimpleMessage;
import com.api.stockservice.domain.event.UserIdResponse;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.amqp.core.MessagePostProcessor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.UUID;
@Service
public class GetUserIdSender {
    @Autowired
    private RabbitTemplate rabbitTemplate;

    public GetUserIdSender(RabbitTemplate rabbitTemplate) {
        this.rabbitTemplate = rabbitTemplate;
    }

    public void sendMessageAndReceiveResponse(String messageText) {
        SimpleMessage simpleMessage = new SimpleMessage(messageText);

        MessagePostProcessor messagePostProcessor = msg -> {
            String correlationId = UUID.randomUUID().toString();
            msg.getMessageProperties().setCorrelationId(correlationId);
            msg.getMessageProperties().setReplyTo("amq.rabbitmq.reply-to");
            System.out.println("CorrelationId: " + correlationId);
            return msg;
        };


        // Send the message and wait for the reply
        UserIdResponse response = (UserIdResponse)rabbitTemplate.convertSendAndReceive(
                "getuserexchange",    // Exchange
                "requestRoutingKey",  // Routing key
                simpleMessage,        // Message body
                messagePostProcessor  // Headers
        );

        if (response != null) {
            System.out.println("Received Response: " + response.toString());
        } else {
            System.out.println("No response received.");
        }
    }
}
