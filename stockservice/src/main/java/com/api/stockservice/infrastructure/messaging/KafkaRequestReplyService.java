package com.api.stockservice.infrastructure.messaging;

import com.api.stockservice.domain.event.RequestMessage;
import com.api.stockservice.domain.event.ResponseMessage;
import org.springframework.kafka.annotation.KafkaListener;
import org.springframework.kafka.core.KafkaTemplate;
import org.springframework.stereotype.Service;

@Service
public class KafkaRequestReplyService {

    private final KafkaTemplate<String, ResponseMessage> kafkaTemplate;

    public KafkaRequestReplyService(KafkaTemplate<String, ResponseMessage> kafkaTemplate) {
        this.kafkaTemplate = kafkaTemplate;
    }

    @KafkaListener(topics = "request-topic", groupId = "request-group")
    public void listen(RequestMessage requestMessage) {
        System.out.println("Received Request: " + requestMessage.getPayload());

        // Process the request (business logic)
        ResponseMessage responseMessage = new ResponseMessage();
        responseMessage.setRequestId(requestMessage.getRequestId());
        responseMessage.setResult("Processed: " + requestMessage.getPayload());

        // Send response to the reply topic
        kafkaTemplate.send("reply-topic", responseMessage);
    }
}
