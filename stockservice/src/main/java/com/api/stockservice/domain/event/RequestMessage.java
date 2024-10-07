package com.api.stockservice.domain.event;

import lombok.Data;

@Data
public class RequestMessage {
    private String requestId;
    private String payload;

    // Getters and setters
}

