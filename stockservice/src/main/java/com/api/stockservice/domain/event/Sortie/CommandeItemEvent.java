package com.api.stockservice.domain.event.Sortie;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@AllArgsConstructor
@NoArgsConstructor
@Data
public class CommandeItemEvent {
    private String itemId;
    private int quantity;
}
