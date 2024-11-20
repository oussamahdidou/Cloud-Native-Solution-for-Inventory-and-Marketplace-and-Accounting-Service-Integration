package com.api.stockservice.application.DTOs;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.web.multipart.MultipartFile;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class SupplierDto {
//    private Long supplierId;
    private String name;
    private String email;
    private MultipartFile thumbnail;
}
