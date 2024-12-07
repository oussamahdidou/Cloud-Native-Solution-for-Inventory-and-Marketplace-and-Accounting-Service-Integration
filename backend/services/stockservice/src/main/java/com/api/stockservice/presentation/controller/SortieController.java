package com.api.stockservice.presentation.controller;

import com.api.stockservice.domain.Entities.Product;
import com.api.stockservice.domain.Entities.Sortie;
import com.api.stockservice.domain.IServices.ISortieService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/api/sortie")
public class SortieController {
    private final ISortieService sortieService;
    @Autowired
    public SortieController(ISortieService sortieService) {
        this.sortieService = sortieService;
    }
    @GetMapping("/sorties")
    public List<Sortie> GetAllProduct()
    {
        return sortieService.getAllSorties();
    }
}
