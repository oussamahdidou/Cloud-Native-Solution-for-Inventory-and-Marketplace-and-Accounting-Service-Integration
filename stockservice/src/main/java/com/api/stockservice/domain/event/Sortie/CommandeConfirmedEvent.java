package com.api.stockservice.domain.event.Sortie;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;
import java.time.OffsetDateTime;
import java.util.List;
@Data
@AllArgsConstructor
@NoArgsConstructor
public class CommandeConfirmedEvent {
    private List<CommandeItemEvent> items;
    private OffsetDateTime date;
}
