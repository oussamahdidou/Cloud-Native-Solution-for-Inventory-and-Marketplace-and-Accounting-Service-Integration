package com.api.stockservice.application.DTOs;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class EntreeResponseDto {
    private Long id;
    private Integer quantite;
    private String entreeDate;
    private String productName;
    private String supplierName;
}
