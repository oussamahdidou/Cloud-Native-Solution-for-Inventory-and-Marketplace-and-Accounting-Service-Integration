package com.api.stockservice.infrastructure.config;

import org.springframework.amqp.core.Binding;
import org.springframework.amqp.core.BindingBuilder;
import org.springframework.amqp.core.Queue;
import org.springframework.amqp.core.TopicExchange;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class ReceiveQueueConfig {
    // Define the topic exchange (this should match the one you used in .NET)
    @Bean
    public TopicExchange receiveExchange() {
        return new TopicExchange("receive_exchange");
    }

    // Define the queue (this should also match your .NET queue)
    @Bean
    public Queue receiveQueue() {
        return new Queue("receive_queue", false);
    }

    // Bind the queue to the exchange with the routing key "receive"
    @Bean
    public Binding binding(Queue receiveQueue, TopicExchange receiveExchange) {
        return BindingBuilder.bind(receiveQueue).to(receiveExchange).with("receive");
    }
}
