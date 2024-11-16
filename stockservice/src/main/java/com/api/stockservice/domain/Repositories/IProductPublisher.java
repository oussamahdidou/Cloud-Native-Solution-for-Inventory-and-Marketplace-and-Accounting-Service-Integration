package com.api.stockservice.domain.Repositories;

import com.api.stockservice.application.DTOs.ProductDto;
import com.api.stockservice.domain.Entities.Product;
import com.api.stockservice.domain.event.PoductEvents.ProductAddedEvent;
import com.api.stockservice.domain.event.PoductEvents.ProductDeleteEvent;
import com.api.stockservice.domain.event.PoductEvents.UpdateProductEvent;

public interface IProductPublisher {
        void sendProductAddedEvent(ProductAddedEvent productAddedEvent);
        void sendUpadatedProduct(UpdateProductEvent updateProductEvent);
        void sendIdProduct(ProductDeleteEvent productDeleteEvent);
}
