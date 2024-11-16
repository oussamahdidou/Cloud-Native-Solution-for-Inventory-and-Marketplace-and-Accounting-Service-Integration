package com.api.stockservice.application.DTOs;


import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.web.multipart.MultipartFile;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class UpdateProduct {

    private String name;
    private MultipartFile thumbnail;
    private String description;
    private Double price;
    private Integer quantity;
    private String categoryId;
    private Long supplierId;
}
