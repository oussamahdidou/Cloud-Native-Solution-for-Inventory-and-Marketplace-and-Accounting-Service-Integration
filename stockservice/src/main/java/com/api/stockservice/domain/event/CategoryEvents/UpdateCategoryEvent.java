package com.api.stockservice.domain.event.CategoryEvents;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class UpdateCategoryEvent {
    private String CategoryId;
    private String Name;
    private String Thumbnail;
}
