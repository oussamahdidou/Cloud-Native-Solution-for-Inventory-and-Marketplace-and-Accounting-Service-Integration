package com.api.stockservice.infrastructure.config;

import org.springframework.amqp.core.Binding;
import org.springframework.amqp.core.BindingBuilder;
import org.springframework.amqp.core.DirectExchange;
import org.springframework.amqp.core.Queue;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class SendRabbitMQConfig {

    public static final String SEND_QUEUE = "send_queue";
    public static final String SEND_EXCHANGE = "send_exchange";
    public static final String SEND_ROUTING_KEY = "send";

    @Bean
    public Queue sendQueue() {
        return new Queue(SEND_QUEUE, true);
    }

    @Bean
    public DirectExchange sendExchange() {
        return new DirectExchange(SEND_EXCHANGE);
    }

    @Bean
    public Binding sendBinding() {
        return BindingBuilder
                .bind(sendQueue())
                .to(sendExchange())
                .with(SEND_ROUTING_KEY);
    }
}
