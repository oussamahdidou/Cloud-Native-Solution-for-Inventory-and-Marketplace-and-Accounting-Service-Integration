package com.api.stockservice.domain.event.Sortie;

import com.api.stockservice.domain.Entities.Product;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class SortieItem {
    private String ProductId;
    private int Quantity;
}
