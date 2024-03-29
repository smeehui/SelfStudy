import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
import React, { Fragment, memo, useState } from "react";

import EditForm from "./EditForm";
import axios from "axios";

function EditModal({ id, handleHide, isShow }) {
    console.log(id);
    const [show, setShow] = useState(false);
    const [user, setUser] = useState({
        name: "",
        username: "",
        email: "",
    });
    const handleClose = () => setShow(false);

    const updateUser = async () => {
        let rs = await axios.put(`http://localhost:8080/users/${id}`, user);
        setUser(rs.data);
    };

    return (
        <Fragment>
            <Modal
                show={isShow || show}
                onHide={() => {
                    handleClose();
                    handleHide();
                }}
                size="lg"
            >
                <Modal.Header>
                    Modal title
                    <Button
                        variant="sm border"
                        onClick={() => {
                            handleClose();
                            handleHide();
                        }}
                    >
                        <span>&times;</span>
                    </Button>
                </Modal.Header>

                <Modal.Body>
                    <EditForm setUser={setUser} user={user} id={id}></EditForm>
                </Modal.Body>
                <Modal.Footer>
                    <Button
                        onClick={() => {
                            handleClose();
                            handleHide();
                        }}
                    >
                        Close
                    </Button>
                    <Button
                        onClick={() => {
                            handleClose();
                            handleHide();
                            updateUser();
                        }}
                    >
                        Save changes
                    </Button>
                </Modal.Footer>
            </Modal>
        </Fragment>
    );
}
export default memo(EditModal);
