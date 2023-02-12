import axios from "axios";
import React, { useState } from "react";
import { Button, Form, FormLabel, Row } from "react-bootstrap";

export default function AddUserForm() {
    const [user, setUser] = useState({
        name: "",
        email: "",
        username: "",
    });
    const { name, email, username } = user;
    const handleInput = (e) => {
        setUser({ ...user, [e.target.name]: e.target.value });
    };

    const handleAddNewCustomer = async () => {
        console.log(user);
        await axios.post("http://localhost:8080/users/create", user);
    };
    return (
        <Form className="mb-3">
            <Row className="mb-3">
                <div className="col-lg-6">
                    <FormLabel htmlFor="inputName" className="form-label">
                        Full name
                    </FormLabel>
                    <input
                        type="text"
                        className="form-control"
                        id="inputName"
                        value={name}
                        name="name"
                        onChange={(e) => {
                            handleInput(e);
                        }}
                    />
                </div>
                <div className="col-lg-6">
                    <FormLabel htmlFor="inputEmail" className="form-label">
                        Username
                    </FormLabel>
                    <input
                        type="text"
                        className="form-control"
                        id="inputEmail"
                        value={username}
                        name="username"
                        onChange={(e) => {
                            handleInput(e);
                        }}
                    />
                </div>
            </Row>

            <Row className="mb-3">
                <div className="col-lg-12">
                    <FormLabel htmlFor="inputEmail" className="form-label">
                        Email
                    </FormLabel>
                    <input
                        type="email"
                        className="form-control"
                        id="inputEmail"
                        value={email}
                        name="email"
                        onChange={(e) => {
                            handleInput(e);
                        }}
                    />
                </div>
            </Row>

            <Button
                id="fSubmit"
                variant="outline-primary px-5"
                onClick={handleAddNewCustomer}
            >
                Create
            </Button>
        </Form>
    );
}
