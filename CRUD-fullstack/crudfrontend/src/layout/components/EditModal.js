import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
import React, { Fragment, memo, useState } from "react";

import EditForm from "./EditForm";

function EditModal({ id, handleHide, isShow }) {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
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
                    <EditForm id={id}></EditForm>
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
