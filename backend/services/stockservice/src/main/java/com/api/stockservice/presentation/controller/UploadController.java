package com.api.stockservice.presentation.controller;

import com.api.stockservice.application.Services.CloudinaryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;

@RestController
@RequestMapping("/api/Upload")
public class UploadController {

    private final CloudinaryService cloudinaryService;

    @Autowired
    public UploadController(CloudinaryService cloudinaryService)
    {
        this.cloudinaryService = cloudinaryService;
    }

    @PostMapping(value = "/image", consumes = "multipart/form-data")
    public ResponseEntity<String> UploadImage(@RequestParam("file")MultipartFile file)
    {
        try{
                String Url = cloudinaryService.UploadImage(file);
                return ResponseEntity.ok(Url);
        }catch(IOException e)
        {
            return ResponseEntity.status(500).body("Image upload failed: " + e.getMessage());
        }

    }
}
