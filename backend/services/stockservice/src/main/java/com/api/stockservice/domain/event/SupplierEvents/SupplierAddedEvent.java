package com.api.stockservice.domain.event.SupplierEvents;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class SupplierAddedEvent {
    private Long supplierId;
    private String name;
    private String email;
    private String thumbnail;
}
