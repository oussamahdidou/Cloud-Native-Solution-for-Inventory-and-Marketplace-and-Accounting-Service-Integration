package com.api.stockservice.application.Services;

import com.api.stockservice.application.DTOs.CreateSupplierDto;
import com.api.stockservice.application.DTOs.ProductDto;
import com.api.stockservice.application.DTOs.SupplierDto;
import com.api.stockservice.domain.Entities.Product;
import com.api.stockservice.domain.Entities.Supplier;
import com.api.stockservice.domain.IServices.ISupplierService;
import com.api.stockservice.domain.Repositories.SupplierRepository;
import com.api.stockservice.domain.event.SupplierEvents.SupplierAddedEvent;
import com.api.stockservice.infrastructure.messaging.SupplierPublisher;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.util.List;
import java.util.stream.Collectors;

@Service
public class SupplierService implements ISupplierService {

    private final SupplierRepository supplierRepository;
    private final SupplierPublisher supplierPublisher;
    private final CloudinaryService cloudinaryService;

    @Autowired
    public SupplierService(CloudinaryService cloudinaryService,SupplierRepository supplierRepository, SupplierPublisher supplierPublisher)
    {
        this.supplierPublisher = supplierPublisher;
        this.supplierRepository = supplierRepository;
        this.cloudinaryService = cloudinaryService;
    }
    @Override
    public Supplier createSupllier(SupplierDto supplierDto)
    {
        Supplier supplier = new Supplier();
        supplier.setName(supplierDto.getName());
        supplier.setEmail(supplierDto.getEmail());
        try {
            String urlThumbnail = cloudinaryService.UploadImage(supplierDto.getThumbnail());
            supplier.setThumbnail(urlThumbnail);

        } catch (IOException e) {
            throw new RuntimeException("Failed to upload image to Cloudinary", e);
        }
        Supplier SavedSupplier = supplierRepository.save(supplier);
        supplierPublisher.SendSupplier(new SupplierAddedEvent(SavedSupplier.getId(),SavedSupplier.getName(),SavedSupplier.getEmail(),SavedSupplier.getThumbnail()));
        return  SavedSupplier;
    }
    @Override
    public Supplier GetSupplier(Long ID)
    {
        Supplier supplier = supplierRepository.findById(ID).orElseThrow();
        return supplier;
    }
    public CreateSupplierDto toDto(Supplier supplier)
    {
        return new CreateSupplierDto(supplier.getName(),supplier.getEmail(),supplier.getThumbnail());
    }
    @Override
    public List<Supplier> GetAllSuppliers()
    {
        List<Supplier> ListOfSuppliers = supplierRepository.findAll();
        return ListOfSuppliers;
    }
    public Supplier UpdateSupplier(Long Id, SupplierDto supplierDto)
    {
        Supplier supplier = supplierRepository.findById(Id).orElseThrow();
        if(supplierDto.getName() != null) supplier.setName(supplierDto.getName());
        if(supplierDto.getEmail() != null) supplier.setEmail(supplierDto.getEmail());
        if(supplierDto.getThumbnail() != null)
        {
            try{
                String UrlThumbnail = cloudinaryService.UploadImage(supplierDto.getThumbnail());
                supplier.setThumbnail(UrlThumbnail);
            }catch(IOException e){
                throw new RuntimeException("Failed to upload image to Cloudinary", e);
            }
        }
        return supplierRepository.save(supplier);
    }
    public boolean DeleteSupplier(Long ID)
    {
        if(supplierRepository.existsById(ID))
        {
            supplierRepository.deleteById(ID);
            return true;
        }
        else{
            throw new EntityNotFoundException("supplier with this id = " +ID+ "not found");
        }
    }

}
