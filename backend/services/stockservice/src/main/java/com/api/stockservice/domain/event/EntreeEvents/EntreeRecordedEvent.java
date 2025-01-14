package com.api.stockservice.domain.event.EntreeEvents;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.OffsetDateTime;
@Data
@AllArgsConstructor
@NoArgsConstructor
public class EntreeRecordedEvent {
    private String id;
    private Double price;
    private int quantity;
    private OffsetDateTime date;
}
