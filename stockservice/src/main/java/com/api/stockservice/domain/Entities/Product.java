package com.api.stockservice.domain.Entities;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Data
public class Product {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long productId;
    private String name;
    private String thumbnail;
    private String description;
    private Double price;
    private Integer quantite;

    @ManyToOne
    @JoinColumn(name = "category_id")
    private Category category;

    @ManyToOne
//    @JoinColumn(name = "supplier_id")
    private Supplier supplier;
}
