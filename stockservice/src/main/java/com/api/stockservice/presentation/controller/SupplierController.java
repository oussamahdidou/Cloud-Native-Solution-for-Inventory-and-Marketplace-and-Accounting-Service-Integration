package com.api.stockservice.presentation.controller;

import com.api.stockservice.application.DTOs.SupplierDto;
import com.api.stockservice.application.Services.SupplierService;
import com.api.stockservice.domain.Entities.Supplier;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api/Supplier")
public class SupplierController {

    @Autowired
    SupplierService supplierService;

    @PostMapping()
    public Supplier createSupplier(@RequestBody SupplierDto supplierDto)
    {
        return supplierService.createSupllier(supplierDto);
    }

}
