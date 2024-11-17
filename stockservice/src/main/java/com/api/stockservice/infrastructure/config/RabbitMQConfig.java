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

    @Bean
    public Queue productAddedQueue() {
        return new Queue("product-added", true);
    }

    @Bean
    public FanoutExchange productAddedExchange() {
        return new FanoutExchange("product-exchange");
    }

    @Bean
    public Binding Productbinding(Queue productAddedQueue, FanoutExchange productAddedExchange) {
        return BindingBuilder.bind(productAddedQueue).to(productAddedExchange);
    }

    @Bean
    public Queue productUpdateQueue() {
        return new Queue("product-Update-Queue", true);
    }

    @Bean
    public FanoutExchange productUpdateExchange() {
        return new FanoutExchange("product-Update-exchange");
    }

    @Bean
    public Binding ProductUpdatebinding(Queue productUpdateQueue, FanoutExchange productUpdateExchange) {
        return BindingBuilder.bind(productUpdateQueue).to(productUpdateExchange);
    }
    @Bean
    public Queue DeleteProductQueue() {
        return new Queue("product-Delete-Queue", true);
    }

    @Bean
    public FanoutExchange DeleteProductExchange() {
        return new FanoutExchange("product-Delete-exchange");
    }

    @Bean
    public Binding ProductDeletebinding(Queue DeleteProductQueue, FanoutExchange DeleteProductExchange) {
        return BindingBuilder.bind(DeleteProductQueue).to(DeleteProductExchange);
    }

    @Bean
    public Queue CategoryAddedQueue() {
        return new Queue("Category-added-queue", true);
    }

    @Bean
    public FanoutExchange CategoryAddedExchange() {
        return new FanoutExchange("Category-added-Exchange");
    }

    @Bean
    public Binding Categorybinding(Queue CategoryAddedQueue, FanoutExchange CategoryAddedExchange) {
        return BindingBuilder.bind(CategoryAddedQueue).to(CategoryAddedExchange);
    }
    @Bean
    public Queue UpdateCategorydQueue() {
        return new Queue("Category-Update-queue", true);
    }

    @Bean
    public FanoutExchange UpdateCategoryExchange() {
        return new FanoutExchange("Category-Update-Exchange");
    }

    @Bean
    public Binding UpdateCategorybinding(Queue UpdateCategorydQueue, FanoutExchange UpdateCategoryExchange) {
        return BindingBuilder.bind(UpdateCategorydQueue).to(UpdateCategoryExchange);
    }

    @Bean
    public Queue DeleteCategorydQueue() {
        return new Queue("Category-Delete-queue", true);
    }

    @Bean
    public FanoutExchange DeleteCategoryExchange() {
        return new FanoutExchange("Category-Delete-Exchange");
    }

    @Bean
    public Binding DeleteCategorybinding(Queue DeleteCategorydQueue, FanoutExchange DeleteCategoryExchange) {
        return BindingBuilder.bind(DeleteCategorydQueue).to(DeleteCategoryExchange);
    }

    @Bean
    public Queue SupplierAddedQueue() {
        return new Queue("Supplier-added-queue", true);
    }


    @Bean
    public FanoutExchange SupplierAddedExchange() {
        return new FanoutExchange("Supplier-added-Exchange");
    }

    @Bean
    public Binding Supplierbinding(Queue SupplierAddedQueue, FanoutExchange SupplierAddedExchange) {
        return BindingBuilder.bind(SupplierAddedQueue).to(SupplierAddedExchange);
    }

}
