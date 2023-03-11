import React, { useCallback, useState } from "react";
import axios from "axios";
import { useEffect } from "react";
import { Button, Table } from "react-bootstrap";
import EditModal from "../layout/components/EditModal";
import { Link } from "react-router-dom";

import DeleteModal from "../layout/components/DeleteModal";
import AddUserForm from "./user/AddUserForm";

export default function Home() {
    const [users, setUsers] = useState([]);
    const [editModal, setEditModal] = useState([0, false]);
    const [deleteModal, setDeleteModal] = useState([0, false]);
    const [click, setClick] = useState(false);

    useEffect(() => {
        loadUsers();
        console.log(123);
    }, [click]);

    let loadUsers = async () => {
        const get = await axios.get("http://localhost:8080/users/");
        setUsers(get.data);
    };

    const handleEditUser = (id) => {
        setEditModal([id, true]);
    };
    const handleHideModal = useCallback(() => {
        setEditModal([0, false]);
        setDeleteModal([deleteModal[0], false]);
    }, [deleteModal[0]]);
    const handleDeleteUser = (id) => {
        setDeleteModal([id, true]);
    };
    return (
        <div>
            <AddUserForm setClick={setClick} click={click} />
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th scope="col" className="text-center">
                            #
                        </th>
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
                            <td className="text-center">{index}</td>
                            <td>
                                <Link to={`/view/${user.id}`}>{user.name}</Link>
                            </td>
                            <td>{user.email}</td>
                            <td>{user.username}</td>
                            <td className="text-center">
                                <Button
                                    variant="warning mx-1"
                                    onClick={() => {
                                        handleEditUser(user.id);
                                    }}
                                >
                                    Edit
                                </Button>
                                <Button
                                    variant="danger"
                                    onClick={() => {
                                        handleDeleteUser(user.id);
                                    }}
                                >
                                    Delete
                                </Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>

            <EditModal
                id={editModal[0]}
                isShow={editModal[1]}
                handleHide={handleHideModal}
            />
            <DeleteModal
                id={deleteModal[0]}
                isShow={deleteModal[1]}
                handleHide={handleHideModal}
                setClick={setClick}
                click={click}
            />
        </div>
    );
}
