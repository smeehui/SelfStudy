package com.crud.controller;

import com.crud.model.User;
import com.crud.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/users")
@CrossOrigin("http://localhost:3000")
public class UserController {

    @Autowired
    UserRepository userRepository;


    @GetMapping("/")
    public List<User> getUsers() {
        return userRepository.findAll();
    }
    @GetMapping("/{id}")
    public User getUser(@PathVariable Long id) {
        return userRepository.findById(id).get();
    }


    @PostMapping("/create")
    public User doCreate(@RequestBody User user) {
        return userRepository.save(user);
    }
}
