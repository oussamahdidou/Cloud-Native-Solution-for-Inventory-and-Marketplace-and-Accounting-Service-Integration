package com.api.stockservice.infrastructure.messaging;

import com.api.stockservice.domain.Entities.Product;
import com.api.stockservice.domain.Entities.Sortie;
import com.api.stockservice.domain.Repositories.ProductRepository;
import com.api.stockservice.domain.Repositories.SortieRepository;
import com.api.stockservice.domain.event.Sortie.CommandeConfirmedEvent;
import com.api.stockservice.domain.event.Sortie.CommandeItemEvent;
import com.api.stockservice.domain.event.Sortie.SortieItem;
import com.api.stockservice.domain.event.Sortie.SortieRecordedEvent;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.messaging.handler.annotation.Payload;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class CommandeConfirmationListener {
    private final SortieRepository sortieRepository;
    private final ProductRepository productRepository;
    private final RabbitTemplate rabbitTemplate;
    @Autowired
    public CommandeConfirmationListener(SortieRepository sortieRepository, ProductRepository productRepository, RabbitTemplate rabbitTemplate) {
        this.sortieRepository = sortieRepository;
        this.productRepository = productRepository;
        this.rabbitTemplate = rabbitTemplate;
    }

    @RabbitListener(queues = "commande_confirmed_queue")
    public void receiveMessage(@Payload CommandeConfirmedEvent commandeConfirmedEvent) {
       List<CommandeItemEvent> commandeItemEvents = commandeConfirmedEvent.getItems();
       List<SortieItem> sortieItems = new ArrayList<SortieItem>();
       for (CommandeItemEvent item : commandeItemEvents){
           Product product = productRepository.findById(item.getItemId()).orElseThrow();
           Sortie sortie = new Sortie();
           sortie.setSortieDate(commandeConfirmedEvent.getDate().toLocalDateTime());
           sortie.setProduct(product);
           sortie.setQuantite(item.getQuantity());
           sortieRepository.save(sortie);
           product.setQuantity(product.getQuantity() - item.getQuantity());
           Product updateProduct = productRepository.save(product);
           sortieItems.add(new SortieItem(updateProduct.getId(), updateProduct.getQuantity()));
       }
        rabbitTemplate.convertAndSend("Sortie-Record-Exchange", "", new SortieRecordedEvent(sortieItems)); // No routing key needed for fanout exchange
    }
}
