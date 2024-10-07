package com.api.stockservice.infrastructure.config;

import org.springframework.amqp.core.Binding;
import org.springframework.amqp.core.BindingBuilder;
import org.springframework.amqp.core.DirectExchange;
import org.springframework.amqp.core.Queue;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
@Configuration
public class GetUserRequestConfig {

    @Bean
    public DirectExchange getUserExchange() {
        return new DirectExchange("getuserexchange");
    }

    @Bean
    public Queue replyQueue() {
        return new Queue("replyQueue");
    }

    @Bean
    public Binding binding(Queue replyQueue, DirectExchange getUserExchange) {
        return BindingBuilder.bind(replyQueue).to(getUserExchange()).with("requestRoutingKey");
    }
}
