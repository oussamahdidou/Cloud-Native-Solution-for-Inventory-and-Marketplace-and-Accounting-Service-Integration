package com.api.stockservice.presentation.controller;

import com.api.stockservice.application.DTOs.CreateEntreeDto;
import com.api.stockservice.application.DTOs.EntreeResponseDto;
import com.api.stockservice.domain.IServices.IEntreeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/entrees")
public class EntreeController {
    private final IEntreeService entreeService;

    @Autowired
    public EntreeController(IEntreeService entreeService) {
        this.entreeService = entreeService;
    }

    @PostMapping
    public ResponseEntity<EntreeResponseDto> createEntree(@RequestBody CreateEntreeDto createEntreeDto) {
        try {
            EntreeResponseDto response = entreeService.createEntree(createEntreeDto);
            return ResponseEntity.status(HttpStatus.CREATED).body(response);
        } catch (Exception ex) {
            ex.printStackTrace(); // Log exception for debugging
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @GetMapping
    public List<EntreeResponseDto> getAllEntrees() {
        return  entreeService.getAllEntrees();
    }

    @GetMapping("/{id}")
    public ResponseEntity<EntreeResponseDto> getEntreeById(@PathVariable Long id) {
        EntreeResponseDto entreeResponse = entreeService.getEntreeById(id);
        return ResponseEntity.ok(entreeResponse);
    }
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteEntree(@PathVariable Long id) {
        try {
            entreeService.deleteEntree(id);
            return ResponseEntity.noContent().build();
        } catch (Exception ex) {
            ex.printStackTrace();
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }
    @PutMapping("/{id}")
    public ResponseEntity<EntreeResponseDto> updateEntree(@PathVariable Long id, @RequestBody CreateEntreeDto createEntreeDto) {
        try {
            EntreeResponseDto response = entreeService.updateEntree(id, createEntreeDto);
            return ResponseEntity.ok(response);
        } catch (Exception ex) {
            ex.printStackTrace();
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }
}
