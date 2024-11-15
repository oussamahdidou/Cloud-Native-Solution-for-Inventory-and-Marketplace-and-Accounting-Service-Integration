//package com.api.stockservice.presentation.controller;
//
//import com.api.stockservice.application.Services.ProductService;
//import com.api.stockservice.domain.Entities.Product;
//import com.api.stockservice.infrastructure.messaging.MyEventPublisher;
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.http.ResponseEntity;
//import org.springframework.security.core.Authentication;
//import org.springframework.security.core.context.SecurityContextHolder;
//import org.springframework.web.bind.annotation.*;
//import org.springframework.web.client.RestTemplate;
//
//@RestController
//@RequestMapping("/api/product")
//public class MyEventController {
//
////    private final MyEventPublisher myEventPublisher;
////    private final RestTemplate restTemplate;
//    private final ProductService productService;
//
//    @Autowired
//    public MyEventController(ProductService productService) {
////        this.myEventPublisher = myEventPublisher;
////        this.restTemplate = restTemplate;
//        this.productService = productService;
//    }
//
//
////    @PostMapping("/publish")
////    public String publishEvent(@RequestBody String value) {
////        myEventPublisher.publishEvent(value);
////        return "Event published successfully!";
////    }
////    @PostMapping("/send-message")
////    public ResponseEntity<String> getUserId() {
////
////        return ResponseEntity.ok("wjh zft");
////    }
//    @PostMapping()
//    public Product addProduct(@RequestBody Product product) {
//        return productService.addProduct(product);
//    }
//}