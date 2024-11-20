package com.api.stockservice.domain.event.PoductEvents;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class ProductDeleteEvent {
    String Id;
}
