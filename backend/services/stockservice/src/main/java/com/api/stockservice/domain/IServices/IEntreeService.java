package com.api.stockservice.domain.IServices;

import com.api.stockservice.application.DTOs.CreateEntreeDto;
import com.api.stockservice.application.DTOs.EntreeResponseDto;
import com.api.stockservice.domain.Entities.Entree;

import java.util.List;

public interface IEntreeService {
    Entree createEntree(CreateEntreeDto createEntreeDto);
    List<Entree> getAllEntrees();
    Entree getEntreeById(Long id);
    void deleteEntree(Long id);
    Entree updateEntree(Long id, CreateEntreeDto createEntreeDto);
}
