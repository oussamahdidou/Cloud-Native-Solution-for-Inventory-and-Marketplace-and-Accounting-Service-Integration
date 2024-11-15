package com.api.stockservice.application.DTOs;


import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class UpdateProduct {

    private String name;
    private String thumbnail;
    private String description;
    private Double price;
    private Integer quantity;
    private Long categoryId;
    private Long supplierId;
}
