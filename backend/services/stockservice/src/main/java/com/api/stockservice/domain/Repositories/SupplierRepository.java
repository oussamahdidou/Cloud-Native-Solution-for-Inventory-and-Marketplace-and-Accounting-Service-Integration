package com.api.stockservice.domain.Repositories;

import com.api.stockservice.domain.Entities.Supplier;
import org.springframework.data.jpa.repository.JpaRepository;

public interface SupplierRepository extends JpaRepository<Supplier, Long> {
}
