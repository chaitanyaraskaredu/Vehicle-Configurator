package com.vita.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

import com.vita.model.CarDescription;
import com.vita.service.CarDescriptionService;

@RestController
@RequestMapping("/api/cars")
public class CarDescriptionController {

    @Autowired
    private CarDescriptionService service;
    @Autowired
    private RestTemplate restTemplate;
    @GetMapping("/")
    public ResponseEntity<List<CarDescription>> getAllCars() {
        List<CarDescription> cars = service.getAllCars();
        return new ResponseEntity<>(cars, HttpStatus.OK);
    }

    /*
  //using mysql and spring boot
    @GetMapping("/{id}")
    public ResponseEntity<CarDescription> getCarById(@PathVariable("id") Long id) {
        Optional<CarDescription> car = service.getCarById(id);
        return car.map(ResponseEntity::ok)
                  .orElseGet(() -> ResponseEntity.notFound().build());
    }


*/
    
    
  
    //using Dot Net SQL-Server DB and API
     
    @GetMapping("/{id}")
    public ResponseEntity<CarDescription> getCarById(@PathVariable("id") Long id) {
        String url = "http://localhost:5248/api/cars/" + id;
        System.out.println("Fetching URL: " + url);

        try {
            CarDescription car = restTemplate.getForObject(url, CarDescription.class);
            System.out.println("Received response: " + car);

            if (car != null) {
                return ResponseEntity.ok(car);
            } else {
                return ResponseEntity.notFound().build();
            }
        } catch (Exception e) {
            System.err.println("Error fetching car data from .NET API: " + e.getMessage());
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }
    }

   

    

