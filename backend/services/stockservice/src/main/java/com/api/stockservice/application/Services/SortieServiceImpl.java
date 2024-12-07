package com.api.stockservice.application.Services;

import com.api.stockservice.domain.Entities.Sortie;
import com.api.stockservice.domain.IServices.ISortieService;
import com.api.stockservice.domain.Repositories.SortieRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
@Service
public class SortieServiceImpl implements ISortieService {
    private SortieRepository sortieRepository;
    @Autowired
    public SortieServiceImpl(SortieRepository sortieRepository) {
        this.sortieRepository = sortieRepository;
    }


    @Override
    public List<Sortie> getAllSorties() {
        return sortieRepository.findAll();
    }
}
