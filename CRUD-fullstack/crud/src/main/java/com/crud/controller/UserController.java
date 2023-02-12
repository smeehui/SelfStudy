package com.crud.controller;

import com.crud.exception.UserNotFoundException;
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
        return userRepository.findById(id).orElseThrow(() -> new UserNotFoundException(id));
    }


    @PostMapping("/create")
    public User doCreate(@RequestBody User user) {
        return userRepository.save(user);
    }

    @PutMapping("/{id}")
    public User doUpdate(@RequestBody User newUser, @PathVariable Long id) {
        return userRepository.findById(id).map(user -> {
            user.setUsername(newUser.getUsername());
            user.setEmail(newUser.getEmail());
            user.setName(newUser.getName());
            return userRepository.save(user);
        }).orElseThrow(() -> new UserNotFoundException(id));
    }

    @DeleteMapping("/{id}")
    public String doDelete(@PathVariable Long id) {
        if (!userRepository.existsById(id)) throw new UserNotFoundException(id);
        else userRepository.deleteById(id);
        return "User has been deleted successfully";
    }
}
