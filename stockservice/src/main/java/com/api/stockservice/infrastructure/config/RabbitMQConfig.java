package com.api.stockservice.infrastructure.config;

import org.springframework.amqp.core.*;
import org.springframework.amqp.rabbit.connection.ConnectionFactory;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.amqp.support.converter.Jackson2JsonMessageConverter;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;


@Configuration
public class RabbitMQConfig {

    @Bean
    public RabbitTemplate rabbitTemplate(ConnectionFactory connectionFactory) {
        RabbitTemplate rabbitTemplate = new RabbitTemplate(connectionFactory);
        rabbitTemplate.setMessageConverter(new Jackson2JsonMessageConverter());
        rabbitTemplate.setReplyTimeout(10000); // 10 seconds
        return rabbitTemplate;
    }

    @Bean
    public Jackson2JsonMessageConverter producerJackson2MessageConverter() {
        return new Jackson2JsonMessageConverter();
    }
    @Bean
    public Queue standaloneQueue() {
        // The second argument 'false' means the queue is not durable.
        return new Queue("test-request-queue", false);
    }
    @Bean
    public Queue myQueue() {
        return new Queue("spring-boot-queue", true);
    }

    @Bean
    public FanoutExchange myExchange() {
        return new FanoutExchange("publish_exchange");
    }

    @Bean
    public Binding binding(Queue myQueue, FanoutExchange myExchange) {
        return BindingBuilder.bind(myQueue).to(myExchange);
    }
}
