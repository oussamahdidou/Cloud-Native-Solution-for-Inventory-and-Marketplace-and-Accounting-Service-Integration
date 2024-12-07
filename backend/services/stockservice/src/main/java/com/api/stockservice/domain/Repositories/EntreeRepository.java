package com.api.stockservice.domain.Repositories;

import com.api.stockservice.domain.Entities.Entree;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface EntreeRepository extends JpaRepository<Entree, Long> {
    @Query(value = """
        WITH months AS (
            SELECT 
                DATE_TRUNC('month', NOW()) - INTERVAL '1 month' * generate_series(0, 11) AS month
        )
        SELECT 
            TO_CHAR(m.month, 'Mon') AS month_name,
            COALESCE(SUM(e.quantite), 0) AS total_entries
        FROM 
            months m
        LEFT JOIN 
            entree e
        ON 
            DATE_TRUNC('month', e.entree_date) = m.month
        GROUP BY 
            m.month
        ORDER BY 
            m.month
        """, nativeQuery = true)
    List<Object[]> getMonthlyPerformance();
    @Query(value = """
        WITH days AS (
            SELECT 
                CURRENT_DATE - generate_series(0, 6) AS day
        )
        SELECT 
            TO_CHAR(d.day, 'Day') AS day_name,
            COALESCE(SUM(e.quantite), 0) AS total_entries
        FROM 
            days d
        LEFT JOIN 
            entree e
        ON 
            DATE(e.entree_date) = d.day
        GROUP BY 
            d.day
        ORDER BY 
            d.day
        """, nativeQuery = true)
    List<Object[]> getLastWeekPerformance();
}
