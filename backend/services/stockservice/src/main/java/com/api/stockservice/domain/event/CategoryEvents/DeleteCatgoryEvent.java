package com.api.stockservice.domain.event.CategoryEvents;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class DeleteCatgoryEvent {
    String CategoryId;
}
