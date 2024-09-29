package com.api.stockservice.infrastructure.config;

import org.springframework.amqp.core.Binding;
import org.springframework.amqp.core.BindingBuilder;
import org.springframework.amqp.core.Queue;
import org.springframework.amqp.core.DirectExchange;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class RabbitMQConfig {

    public static final String ARTICLE_QUEUE = "article_created_queue";
    public static final String ARTICLE_EXCHANGE = "article_exchange";
    public static final String ARTICLE_ROUTING_KEY = "article_created";

    // Declare a queue
    @Bean
    public Queue articleQueue() {
        return new Queue(ARTICLE_QUEUE, true); // durable queue
    }

    // Declare a direct exchange
    @Bean
    public DirectExchange articleExchange() {
        return new DirectExchange(ARTICLE_EXCHANGE);
    }

    // Binding the queue and exchange with a routing key
    @Bean
    public Binding binding() {
        return BindingBuilder
                .bind(articleQueue())
                .to(articleExchange())
                .with(ARTICLE_ROUTING_KEY);
    }
}
