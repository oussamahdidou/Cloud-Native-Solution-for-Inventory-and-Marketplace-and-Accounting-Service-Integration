package com.api.stockservice.application.Services;

import com.api.stockservice.application.DTOs.ProductCreateDto;
import com.api.stockservice.application.DTOs.ProductDto;
import com.api.stockservice.domain.Entities.Category;
import com.api.stockservice.domain.Entities.Supplier;
import com.api.stockservice.domain.Repositories.CategoryRepository;
import com.api.stockservice.domain.Repositories.IProductPublisher;
import com.api.stockservice.domain.Entities.Product;
import com.api.stockservice.domain.IServices.IProductService;
import com.api.stockservice.domain.Repositories.ProductRepository;
import com.api.stockservice.domain.Repositories.SupplierRepository;
import com.api.stockservice.domain.event.PoductEvents.ProductAddedEvent;
import com.api.stockservice.domain.event.PoductEvents.ProductDeleteEvent;
import com.api.stockservice.domain.event.PoductEvents.UpdateProductEvent;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.util.List;
import java.util.stream.Collectors;

@Service
public class ProductService implements IProductService {

    private final ProductRepository productRepository;
    private final IProductPublisher productPublisher;
//    private final IProductMapper productMapper;
    private final CategoryRepository categoryRepository;
    private final SupplierRepository supplierRepository;
    private final CloudinaryService cloudinaryService;

    public ProductService(ProductRepository productRepository,IProductPublisher productPublisher, CategoryRepository categoryRepository, SupplierRepository supplierRepository, CloudinaryService cloudinaryService) {
        this.productRepository = productRepository;
        this.productPublisher = productPublisher;
        this.categoryRepository = categoryRepository;
        this.supplierRepository = supplierRepository;
        this.cloudinaryService = cloudinaryService;
    }

    @Override
    public Product addProduct(ProductDto productDto) {
        Category category = categoryRepository.findById(productDto.getCategoryId()).orElseThrow();
        Supplier supplier = supplierRepository.findById(productDto.getSupplierId()).orElseThrow();

        Product product = new Product();
        product.setName(productDto.getName());

        try {
            String urlThumbnail = cloudinaryService.UploadImage(productDto.getThumbnail());
            product.setThumbnail(urlThumbnail);

        } catch (IOException e) {
            throw new RuntimeException("Failed to upload image to Cloudinary", e);
        }
        product.setDescription(productDto.getDescription());
        product.setPrice(productDto.getPrice());
        product.setQuantity(productDto.getQuantity());
        product.setCategory(category);
        product.setSupplier(supplier);
        Product savedProduct = productRepository.save(product);
        productPublisher.sendProductAddedEvent(new ProductAddedEvent(savedProduct.getId(), supplier.getName(),supplier.getThumbnail(),savedProduct.getName(),savedProduct.getDescription(),savedProduct.getPrice(),savedProduct.getQuantity(),savedProduct.getThumbnail(),category.getId()));
        return savedProduct;
    }
    @Override
    public Product UpdateProduct(String ProductId, ProductDto productDto)
    {
        Product product = productRepository.findById(ProductId).orElseThrow();
        if (productDto.getName() != null) product.setName(productDto.getName());
        if(productDto.getThumbnail()  != null)
        {
            try{
                String UrlThumbnail = cloudinaryService.UploadImage(productDto.getThumbnail());
                product.setThumbnail(UrlThumbnail);
            }catch(IOException e){
                throw new RuntimeException("Failed to upload image to Cloudinary", e);
            }
        }
        if (productDto.getDescription() != null) product.setDescription(productDto.getDescription());
        if (productDto.getPrice() != null) product.setPrice(productDto.getPrice());
        if (productDto.getQuantity() !=null) product.setQuantity(productDto.getQuantity());

        if (productDto.getCategoryId() != null)
        {
            Category category = categoryRepository.findById(productDto.getCategoryId()).orElseThrow();
            product.setCategory(category);
        }

        if(productDto.getSupplierId() != null)
        {
            Supplier supplier = supplierRepository.findById(productDto.getSupplierId()).orElseThrow();
            product.setSupplier(supplier);
        }
        Product UpdatedProduct = productRepository.save(product);
        productPublisher.sendUpadatedProduct(new UpdateProductEvent(UpdatedProduct.getId(),UpdatedProduct.getSupplier().getName(),UpdatedProduct.getSupplier().getThumbnail(),UpdatedProduct.getName(),UpdatedProduct.getDescription(),UpdatedProduct.getPrice(),UpdatedProduct.getQuantity(),UpdatedProduct.getThumbnail(),UpdatedProduct.getCategory().getId()));
        return UpdatedProduct;
    }
    @Override
    public ProductCreateDto getproduct(String ProductID)
    {
        Product product = productRepository.findById(ProductID).orElseThrow(() -> new RuntimeException("Product not found "));
        return  toDto(product);
    }
    @Override
    public List<ProductCreateDto> getALLProduct()
    {
        List<Product> ListOfProduct = productRepository.findAll();
        List<ProductCreateDto> ListOfProductDto = ListOfProduct.stream().map(this::toDto).collect(Collectors.toList());
        return ListOfProductDto;
    }
    private ProductCreateDto toDto(Product product)
    {
        return new ProductCreateDto(
                product.getName(),
                product.getThumbnail(),
                product.getDescription(),
                product.getPrice(),
                product.getQuantity(),
                product.getCategory().getId(),
                product.getSupplier().getId()
        );
    }
    @Override
    public boolean DeleteProduct(String ProductId)
    {
        if(productRepository.existsById(ProductId))
        {
            productRepository.deleteById(ProductId);
            productPublisher.sendIdProduct(new ProductDeleteEvent(ProductId));
            return true;

        }
        else{
            throw new EntityNotFoundException("product with " + ProductId + "not found");
        }
    }
}
