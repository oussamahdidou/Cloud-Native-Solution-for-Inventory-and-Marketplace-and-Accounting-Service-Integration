package com.api.stockservice.domain.event;

import lombok.Data;

@Data
public class MyEvent {
    public String Value;
    public void setValue(String value) {
        Value = value;
    }
    public String getValue() {
        return Value;
    }
}
