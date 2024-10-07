package com.api.stockservice.domain.event;

import lombok.Data;

@Data
public class ResponseMessage {
    private String requestId;
    private String result;

    // Getters and setters
}
