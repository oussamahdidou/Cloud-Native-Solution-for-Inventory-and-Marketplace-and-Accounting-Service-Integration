package com.api.stockservice.presentation.controller;

import com.api.stockservice.application.DTOs.SupplierDto;
import com.api.stockservice.application.Services.SupplierService;
import com.api.stockservice.domain.Entities.Supplier;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

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
    @GetMapping("/{IdSupplier}")
    public SupplierDto GetSupplier(@PathVariable  Long id)
    {
        return supplierService.GetSupplier(id);
    }

    @GetMapping("Suppliers")
    public List<SupplierDto> GetAllSuppliers()
    {
        return supplierService.GetAllSuppliers();
    }

    @PutMapping("/{SupplierID}")
    public SupplierDto UpdateSupplier(@PathVariable Long id,@RequestBody SupplierDto supplierDto)
    {
        return supplierService.UpdateSupplier(id , supplierDto);
    }
    @DeleteMapping("{SupplierID}")
    public boolean DeleteSupplier(@PathVariable  Long id)
    {
        return supplierService.DeleteSupplier(id);
    }

}
