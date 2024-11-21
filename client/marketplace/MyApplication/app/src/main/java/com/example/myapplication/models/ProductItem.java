package com.example.myapplication.models;

// Product.java
public class ProductItem {
    private String productId;
    private String name;
    private double price;
    private String thumbnail;
    private int quantity;

    // Default constructor
    public ProductItem() {}

    // Parameterized constructor
    public ProductItem(String productId, String name, double price, String thumbnail, int quantity) {
        this.productId = productId;
        this.name = name;
        this.price = price;
        this.thumbnail = thumbnail;
        this.quantity = quantity;
    }

    // Getters and Setters
    public String getProductId() {
        return productId;
    }

    public void setProductId(String productId) {
        this.productId = productId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public String getThumbnail() {
        return thumbnail;
    }

    public void setThumbnail(String thumbnail) {
        this.thumbnail = thumbnail;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

}

