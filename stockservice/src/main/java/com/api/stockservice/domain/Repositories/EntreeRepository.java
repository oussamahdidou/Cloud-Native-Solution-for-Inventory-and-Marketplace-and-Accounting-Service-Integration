package com.api.stockservice.domain.Repositories;

import com.api.stockservice.domain.Entities.Entree;
import org.springframework.data.jpa.repository.JpaRepository;

public interface EntreeRepository extends JpaRepository<Entree, Long> {
}
