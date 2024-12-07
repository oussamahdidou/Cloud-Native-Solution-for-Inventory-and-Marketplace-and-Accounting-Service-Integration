package com.api.stockservice.presentation.controller;

import com.api.stockservice.application.DTOs.PerformanceDTO;
import com.api.stockservice.domain.IServices.DashboardService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/dashboard")
public class DashboardController {

    private final DashboardService dashboardService;

    @Autowired
    public DashboardController(DashboardService dashboardService) {
        this.dashboardService = dashboardService;
    }

    @GetMapping("/entries/monthly-performance")
    public List<PerformanceDTO> getEntriesMonthlyPerformance() {
        return dashboardService.GetEnteriesMonthlyPerformance();
    }

    @GetMapping("/sorties/monthly-performance")
    public List<PerformanceDTO> getSortiesMonthlyPerformance() {
        return dashboardService.GetSortiesMonthlyPerformance();
    }

    @GetMapping("/entries/weekly-performance")
    public List<PerformanceDTO> getEntriesWeeklyPerformance() {
        return dashboardService.GetEnteriesWeeklyPerformance();
    }

    @GetMapping("/sorties/weekly-performance")
    public List<PerformanceDTO> getSortiesWeeklyPerformance() {
        return dashboardService.GetSortiesWeeklyPerformance();
    }
}
