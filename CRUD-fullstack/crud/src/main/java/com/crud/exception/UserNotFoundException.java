package com.crud.exception;

public class UserNotFoundException extends RuntimeException {
    public UserNotFoundException(Long id) {
        super("User not with id "+id+" is not found, please try again!");
    }
}
