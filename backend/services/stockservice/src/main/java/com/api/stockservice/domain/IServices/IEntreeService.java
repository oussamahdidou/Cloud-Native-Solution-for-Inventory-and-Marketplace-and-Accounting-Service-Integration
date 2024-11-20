package com.api.stockservice.domain.IServices;

import com.api.stockservice.application.DTOs.CreateEntreeDto;
import com.api.stockservice.application.DTOs.EntreeResponseDto;

import java.util.List;

public interface IEntreeService {
    EntreeResponseDto createEntree(CreateEntreeDto createEntreeDto);
    List<EntreeResponseDto> getAllEntrees();
    EntreeResponseDto getEntreeById(Long id);
    void deleteEntree(Long id);
    EntreeResponseDto updateEntree(Long id, CreateEntreeDto createEntreeDto);
}
