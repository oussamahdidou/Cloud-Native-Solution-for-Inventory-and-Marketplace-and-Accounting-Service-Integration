package com.api.stockservice.application.Services;

import com.api.stockservice.application.DTOs.PerformanceDTO;
import com.api.stockservice.domain.IServices.DashboardService;
import com.api.stockservice.domain.Repositories.EntreeRepository;
import com.api.stockservice.domain.Repositories.SortieRepository;
import org.springframework.stereotype.Service;

import java.util.List;
@Service
public class DashboardServiceImpl implements DashboardService {
    private  final EntreeRepository entreeRepository;
    private  final SortieRepository sortieRepository;

    public DashboardServiceImpl(EntreeRepository entreeRepository, SortieRepository sortieRepository) {
        this.entreeRepository = entreeRepository;
        this.sortieRepository = sortieRepository;
    }

    @Override
    public List<PerformanceDTO> GetEnteriesMonthlyPerformance() {

        List<Object[]> results = entreeRepository.getMonthlyPerformance();
        return results.stream()
                .map(row -> new PerformanceDTO(((String) row[0]).trim(), ((Number) row[1]).intValue()))
                .toList();
    }

    @Override
    public List<PerformanceDTO> GetSortiesMonthlyPerformance() {
        List<Object[]> results = sortieRepository.getMonthlyPerformance();
        return results.stream()
                .map(row -> new PerformanceDTO(((String) row[0]).trim(), ((Number) row[1]).intValue()))
                .toList();
    }

    @Override
    public List<PerformanceDTO> GetEnteriesWeeklyPerformance() {
        List<Object[]> results = entreeRepository.getLastWeekPerformance();
        return results.stream()
                .map(row -> new PerformanceDTO(((String) row[0]).trim(), ((Number) row[1]).intValue()))
                .toList();
    }

    @Override
    public List<PerformanceDTO> GetSortiesWeeklyPerformance() {
        List<Object[]> results = sortieRepository.getLastWeekPerformance();
        return results.stream()
                .map(row -> new PerformanceDTO(((String) row[0]).trim(), ((Number) row[1]).intValue()))
                .toList();
    }
}
