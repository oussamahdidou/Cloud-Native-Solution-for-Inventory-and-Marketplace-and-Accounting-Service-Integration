package com.api.stockservice.application.Services;

import com.api.stockservice.application.DTOs.CreateEntreeDto;
import com.api.stockservice.domain.Entities.Entree;
import com.api.stockservice.domain.Entities.Product;
import com.api.stockservice.domain.Entities.Supplier;
import com.api.stockservice.domain.IServices.IEntreeService;
import com.api.stockservice.domain.Repositories.EntreeRepository;
import com.api.stockservice.domain.Repositories.IProductPublisher;
import com.api.stockservice.domain.Repositories.ProductRepository;
import com.api.stockservice.domain.Repositories.SupplierRepository;
import com.api.stockservice.domain.event.PoductEvents.UpdateProductEvent;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class EntreeServiceImpl implements IEntreeService {
    private final EntreeRepository entreeRepository;
    private final ProductRepository productRepository;
    private final SupplierRepository supplierRepository;
    private final IProductPublisher productPublisher;

    public EntreeServiceImpl(IProductPublisher productPublisher,EntreeRepository entreeRepository, ProductRepository productRepository, SupplierRepository supplierRepository) {
        this.entreeRepository = entreeRepository;
        this.productRepository = productRepository;
        this.supplierRepository = supplierRepository;
        this.productPublisher = productPublisher;
    }

    @Override
    public Entree createEntree(CreateEntreeDto createEntreeDto) {
        try {
            Product product = productRepository.findById(createEntreeDto.getProductId())
                    .orElseThrow(() -> new RuntimeException("Product not found"));
            Supplier supplier = supplierRepository.findById(createEntreeDto.getSupplierId())
                    .orElseThrow(() -> new RuntimeException("Supplier not found"));

            Entree entree = new Entree();
            entree.setQuantite(createEntreeDto.getQuantite());
            entree.setEntreeDate(createEntreeDto.getEntreeDate());
            entree.setProduct(product);
            entree.setSupplier(supplier);

            Entree savedEntree = entreeRepository.save(entree);
            product.setQuantity(product.getQuantity() + createEntreeDto.getQuantite());
            Product savedProduct = productRepository.save(product);
            System.out.println(savedProduct);
            productPublisher.sendUpadatedProduct(new UpdateProductEvent(savedProduct.getId(),
                    savedProduct.getSupplier().getName(),savedProduct.getSupplier().getThumbnail(),
                    savedProduct.getName(),savedProduct.getDescription(),savedProduct.getPrice(),
                    savedProduct.getQuantity(),savedProduct.getThumbnail(),
                    savedProduct.getCategory().getId()));
            return savedEntree;
        }catch (Exception e)
        {
            e.printStackTrace();
            throw new RuntimeException("failed to save entree " + e.getMessage());
        }
    }

    @Override
    public List<Entree> getAllEntrees() {
        return entreeRepository.findAll();
    }

    @Override
    public Entree getEntreeById(Long id) {
        Entree entree = entreeRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Entree not found"));
        return entree;
    }
    @Override
    public void deleteEntree(Long id) {
        try {
            Entree entree = entreeRepository.findById(id)
                    .orElseThrow(() -> new RuntimeException("Entree not found"));
            String ProductId= entree.getProduct().getId();
            Product product = productRepository.findById(ProductId).orElseThrow();
            product.setQuantity(product.getQuantity()-entree.getQuantite());
            Product savedProduct = productRepository.save(product);
            productPublisher.sendUpadatedProduct(new UpdateProductEvent(savedProduct.getId(),
                    savedProduct.getSupplier().getName(),savedProduct.getSupplier().getThumbnail(),
                    savedProduct.getName(),savedProduct.getDescription(),savedProduct.getPrice(),
                    savedProduct.getQuantity(),savedProduct.getThumbnail(),
                    savedProduct.getCategory().getId()));

            entreeRepository.delete(entree);
        } catch (Exception e) {
            e.printStackTrace();
            throw new RuntimeException("Failed to delete entree: " + e.getMessage());
        }
    }
    @Override
    public Entree updateEntree(Long id, CreateEntreeDto createEntreeDto) {
        try {
            Product product = productRepository.findById(createEntreeDto.getProductId())
                    .orElseThrow(() -> new RuntimeException("Product not found"));
            Supplier supplier = supplierRepository.findById(createEntreeDto.getSupplierId())
                    .orElseThrow(() -> new RuntimeException("Supplier not found"));

            Entree entree = entreeRepository.findById(id)
                    .orElseThrow(() -> new RuntimeException("Entree not found"));
            Integer lastQuntity = entree.getQuantite();

            entree.setQuantite(createEntreeDto.getQuantite());
            entree.setEntreeDate(createEntreeDto.getEntreeDate());
            entree.setProduct(product);
            entree.setSupplier(supplier);

            product.setQuantity(product.getQuantity() - (lastQuntity - createEntreeDto.getQuantite()));
            Product savedProduct = productRepository.save(product);
            productPublisher.sendUpadatedProduct(new UpdateProductEvent(savedProduct.getId(),
                    savedProduct.getSupplier().getName(),savedProduct.getSupplier().getThumbnail(),
                    savedProduct.getName(),savedProduct.getDescription(),savedProduct.getPrice(),
                    savedProduct.getQuantity(),savedProduct.getThumbnail(),
                    savedProduct.getCategory().getId()));

            Entree updatedEntree = entreeRepository.save(entree);


            return updatedEntree;
        } catch (Exception e) {
            e.printStackTrace();
            throw new RuntimeException("Failed to update entree: " + e.getMessage());
        }
    }
}


