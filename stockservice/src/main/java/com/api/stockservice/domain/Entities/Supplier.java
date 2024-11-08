package com.api.stockservice.domain.Entities;
import lombok.Data;
import jakarta.persistence.*;


@Entity
@Data
public class Supplier {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long supplierId;
    private String name;
    private String email;
    private String thumbnail;
}
