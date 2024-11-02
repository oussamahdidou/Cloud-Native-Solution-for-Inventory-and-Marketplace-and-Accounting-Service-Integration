package com.api.stockservice.domain.Repositories;

import com.api.stockservice.domain.Entities.Sortie;
import org.springframework.data.jpa.repository.JpaRepository;

public interface SortieRepository extends JpaRepository<Sortie, Long> {
}
