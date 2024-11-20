package com.api.stockservice.domain.Repositories;

import com.api.stockservice.application.DTOs.SupplierDto;
import com.api.stockservice.domain.event.SupplierEvents.SupplierAddedEvent;

public interface ISupplierPublisher {
    void SendSupplier(SupplierAddedEvent supplierAddedEvent);
}
