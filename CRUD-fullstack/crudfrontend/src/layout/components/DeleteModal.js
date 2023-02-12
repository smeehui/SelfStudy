import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
import React, { Fragment, memo, useState } from "react";
import ViewUser from "../../pages/user/ViewUser";
import axios from "axios";

function DeleteModal({ id, handleHide, isShow }) {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    let deleteUser = async () => {
        await axios.delete(`http://localhost:8080/users/${id}`);
    };
    return (
        <>
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
                    <ViewUser userId={id} />
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
                        variant="danger"
                        onClick={() => {
                            deleteUser();
                            handleClose();
                            handleHide();
                        }}
                    >
                        Delete
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
}
export default memo(DeleteModal);
