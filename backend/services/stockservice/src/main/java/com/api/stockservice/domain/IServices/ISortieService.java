package com.api.stockservice.domain.IServices;

import com.api.stockservice.application.DTOs.CreateEntreeDto;
import com.api.stockservice.domain.Entities.Entree;
import com.api.stockservice.domain.Entities.Sortie;

import java.util.List;

public interface ISortieService {
    List<Sortie> getAllSorties();


}
