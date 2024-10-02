package com.api.stockservice.infrastructure.config;

import org.springframework.amqp.core.Binding;
import org.springframework.amqp.core.BindingBuilder;
import org.springframework.amqp.core.DirectExchange;
import org.springframework.amqp.core.Queue;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class ReceiveRabbitMQConfig {

    public static final String RECEIVE_QUEUE = "receive_queue";
    public static final String RECEIVE_EXCHANGE = "receive_exchange";
    public static final String RECEIVE_ROUTING_KEY = "receive";

    @Bean
    public Queue receiveQueue() {
        return new Queue(RECEIVE_QUEUE, true);
    }

    @Bean
    public DirectExchange receiveExchange() {
        return new DirectExchange(RECEIVE_EXCHANGE);
    }

    @Bean
    public Binding receiveBinding() {
        return BindingBuilder
                .bind(receiveQueue())
                .to(receiveExchange())
                .with(RECEIVE_ROUTING_KEY);
    }
}
