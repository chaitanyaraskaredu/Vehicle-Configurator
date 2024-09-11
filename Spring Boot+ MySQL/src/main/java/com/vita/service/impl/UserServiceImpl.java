package com.vita.service.impl;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

import com.vita.model.User;
import com.vita.repositoty.UserRepository;
import com.vita.service.UserService;

@Service
public class UserServiceImpl implements UserService {

    private static final Logger logger = LoggerFactory.getLogger(UserServiceImpl.class);

    @Autowired
    private UserRepository userRepo;

    @PostMapping(value = "/register")
    public User createUser(@RequestBody User user) {
        logger.info("Creating user with email: {}", user.getEmail());
        logger.info("Randomly generated ID is: {}", user.getUserid());
        userRepo.save(user);
        logger.info("User created successfully: {}", user);
        return user;
    }

    public User getUserByEmail(String email) {
        logger.debug("Fetching user by email: {}", email);
        // TODO Auto-generated method stub
        return null;
    }

    public User getUserById(String userid) {
        logger.debug("Fetching user by ID: {}", userid);
        return userRepo.findById(userid).orElse(null);
    }
}
