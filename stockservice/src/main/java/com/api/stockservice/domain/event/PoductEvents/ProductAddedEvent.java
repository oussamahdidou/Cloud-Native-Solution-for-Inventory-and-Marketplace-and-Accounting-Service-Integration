package com.api.stockservice.domain.event.PoductEvents;

import com.api.stockservice.domain.Entities.Category;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class ProductAddedEvent {
    public String Id ;
    public String MarqueName;
    public String MarqueIcon;
    public String Name;
    public String Description;
    public Double Price;
    public Integer Quantity;
    public String Thumbnail;
    public String CategoryId;

}
