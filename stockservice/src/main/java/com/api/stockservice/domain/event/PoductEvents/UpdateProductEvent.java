package com.api.stockservice.domain.event.PoductEvents;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class UpdateProductEvent {
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
