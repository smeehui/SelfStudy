import React, { useCallback, useState } from "react";
import axios from "axios";
import { useEffect } from "react";
import { Button, Table } from "react-bootstrap";
import EditModal from "../layout/components/EditModal";

export default function Home() {
    const [users, setUsers] = useState([]);
    const [modal, setModal] = useState([0, false]);

    useEffect(() => {
        loadUsers();
    }, [users]);

    let loadUsers = async () => {
        const get = await axios.get("http://localhost:8080/users/");
        setUsers(get.data);
    };

    const handleEditUser = (user) => {
        setModal([user.id, true]);
    };
    const handleHideModal = useCallback(() => {
        setModal([0, false]);
    }, []);

    return (
        <div>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Name</th>
                        <th scope="col">Email</th>
                        <th scope="col">Username</th>
                        <th scope="col" className="text-center">
                            Action
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {users.map((user, index) => (
                        <tr key={index}>
                            <td></td>
                            <td>${user.name}</td>
                            <td>${user.email}</td>
                            <td>${user.username}</td>
                            <td className="text-center">
                                <Button
                                    variant="warning mx-1"
                                    onClick={() => {
                                        handleEditUser(user);
                                    }}
                                >
                                    Edit
                                </Button>
                                <Button variant="danger">Delete</Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>

            <EditModal
                id={modal[0]}
                isShow={modal[1]}
                handleHide={handleHideModal}
            ></EditModal>
        </div>
    );
}
