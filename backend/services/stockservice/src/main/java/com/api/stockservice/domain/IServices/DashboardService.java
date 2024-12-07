package com.api.stockservice.domain.IServices;

import com.api.stockservice.application.DTOs.PerformanceDTO;

import java.util.List;

public interface DashboardService {
    List<PerformanceDTO> GetEnteriesMonthlyPerformance();
    List<PerformanceDTO> GetSortiesMonthlyPerformance();
    List<PerformanceDTO> GetEnteriesWeeklyPerformance();
    List<PerformanceDTO> GetSortiesWeeklyPerformance();
}
