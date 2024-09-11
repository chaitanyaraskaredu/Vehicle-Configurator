package com.vita.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.vita.model.User;
import com.vita.service.UserService;

@RestController
@CrossOrigin(origins = "http://localhost:3000") // Replace with your React app URL
@RequestMapping("/api/user")
public class UserController {
	
    @Autowired
    private UserService userService;
	
    @PostMapping("/register")
    public ResponseEntity<String> createUser(@RequestBody User user) {
        try {
            userService.createUser(user);
            
            return new ResponseEntity<>("User registered successfully", HttpStatus.CREATED);
        } catch (Exception e) {
            // Log the exception and return an error response
            return new ResponseEntity<>("Error occurred: " + e.getMessage(), HttpStatus.BAD_REQUEST);
        }
    }
    @GetMapping("/login")
    public ResponseEntity<String> loginUser(@RequestParam String userid, @RequestParam String password) {
        User user = userService.getUserById(userid);
        if (user != null && user.getPassword().equals(password)) {
            return new ResponseEntity<>("Login successful", HttpStatus.OK);
        } else {
            return new ResponseEntity<>("Invalid user ID or password", HttpStatus.UNAUTHORIZED);
        }
    }
    
    @GetMapping("/userForInvoice/{userid}")
    public User userInfoForInvoice(@PathVariable String userid){
    	User user = userService.getUserById(userid);
   
    	return user;
    	
    }
    
   
}
