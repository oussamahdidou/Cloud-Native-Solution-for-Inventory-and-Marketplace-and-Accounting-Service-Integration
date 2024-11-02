package com.api.stockservice.domain.Entities;

import jakarta.persistence.*;
import lombok.Data;
import java.time.LocalDateTime;

@Entity
@Data
public class Sortie {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long sortieId;
    private Integer quantite;
    private LocalDateTime sortieDate;

    @ManyToOne
    @JoinColumn(name = "product_id")
    private Product product;
}
