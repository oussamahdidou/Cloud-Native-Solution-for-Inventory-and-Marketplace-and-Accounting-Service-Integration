package com.api.stockservice.application.DTOs;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.web.multipart.MultipartFile;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class UpdateCategoryDTO {
    private String categoryId;
    private String name;
    private MultipartFile  thumbnail;
}
