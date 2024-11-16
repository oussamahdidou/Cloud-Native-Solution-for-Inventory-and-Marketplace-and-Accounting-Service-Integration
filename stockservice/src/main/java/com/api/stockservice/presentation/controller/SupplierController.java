package com.api.stockservice.presentation.controller;

import com.api.stockservice.application.DTOs.CreateSupplierDto;
import com.api.stockservice.application.DTOs.SupplierDto;
import com.api.stockservice.application.Services.SupplierService;
import com.api.stockservice.domain.Entities.Supplier;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/Supplier")
public class SupplierController {

    @Autowired
    SupplierService supplierService;

    @PostMapping(consumes = MediaType.MULTIPART_FORM_DATA_VALUE)
    public Supplier createSupplier(@ModelAttribute SupplierDto supplierDto)
    {
        return supplierService.createSupllier(supplierDto);
    }
    @GetMapping("/{IdSupplier}")
    public CreateSupplierDto GetSupplier(@PathVariable  Long IdSupplier)
    {
        return supplierService.GetSupplier(IdSupplier);
    }

    @GetMapping("Suppliers")
    public List<CreateSupplierDto> GetAllSuppliers()
    {
        return supplierService.GetAllSuppliers();
    }

    @PutMapping(path ="/{SupplierID}" , consumes = MediaType.MULTIPART_FORM_DATA_VALUE)
    public Supplier UpdateSupplier(@PathVariable Long SupplierID,@ModelAttribute SupplierDto supplierDto)
    {
        return supplierService.UpdateSupplier(SupplierID , supplierDto);
    }
    @DeleteMapping("{SupplierID}")
    public boolean DeleteSupplier(@PathVariable  Long SupplierID)
    {
        return supplierService.DeleteSupplier(SupplierID);
    }

}
