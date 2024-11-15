package com.api.stockservice.application.Services;

import com.api.stockservice.application.DTOs.ProductDto;
import com.api.stockservice.application.DTOs.SupplierDto;
import com.api.stockservice.domain.Entities.Product;
import com.api.stockservice.domain.Entities.Supplier;
import com.api.stockservice.domain.IServices.ISupplierService;
import com.api.stockservice.domain.Repositories.SupplierRepository;
import com.api.stockservice.domain.event.SupplierEvents.SupplierAddedEvent;
import com.api.stockservice.infrastructure.messaging.SupplierPublisher;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class SupplierService implements ISupplierService {

    private final SupplierRepository supplierRepository;
    private final SupplierPublisher supplierPublisher;

    @Autowired
    public SupplierService(SupplierRepository supplierRepository, SupplierPublisher supplierPublisher)
    {
        this.supplierPublisher = supplierPublisher;
        this.supplierRepository = supplierRepository;
    }
    @Override
    public Supplier createSupllier(SupplierDto supplierDto)
    {
        Supplier supplier = new Supplier();
        supplier.setName(supplierDto.getName());
        supplier.setEmail(supplierDto.getEmail());
        supplier.setThumbnail(supplierDto.getThumbnail());
        Supplier SavedSupplier = supplierRepository.save(supplier);
        supplierPublisher.SendSupplier(new SupplierAddedEvent(SavedSupplier.getId(),SavedSupplier.getName(),SavedSupplier.getEmail(),SavedSupplier.getThumbnail()));
        return  SavedSupplier;
    }
//    @Override
//    public SupplierDto GetSupplier(Long ID)
//    {
//        Supplier supplier = supplierRepository.findById(ID).orElseThrow();
//        return toDto(supplier);
//    }
//    public SupplierDto toDto(Supplier supplier)
//    {
//        return new SupplierDto(supplier.getName(),supplier.getEmail(),supplier.getThumbnail());
//    }
//    @Override
//    public List<SupplierDto> GetAllSuppliers()
//    {
//        List<Supplier> ListOfSuppliers = supplierRepository.findAll();
//        return ListOfSuppliers.stream().map(this::toDto).collect(Collectors.toList());
//    }

}
