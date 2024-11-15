package com.api.stockservice.domain.IServices;

import com.api.stockservice.application.DTOs.SupplierDto;
import com.api.stockservice.domain.Entities.Supplier;

import java.util.List;

public interface ISupplierService {
    Supplier createSupllier(SupplierDto supplierDto);
//    SupplierDto GetSupplier(Long ID);
//    List<SupplierDto> GetAllSuppliers();
//    SupplierDto UpdateSupplier(Long ID, SupplierDto supplierDto);
//    boolean DeleteSupplier(Long ID);
}
