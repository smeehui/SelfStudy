import axios from "axios";
import React, { useEffect, useState } from "react";
import { Row } from "react-bootstrap";

export default function EditForm({ id }) {
    const [user, setUser] = useState([]);
    const getUser = async () => {
        const user = await axios
            .get(`http://localhost:8080/users/${id}`)
            .catch((e) => {
                return;
            });
        setUser(user ? user.data : []);
    };
    const handleChange = (event) => {
        let name = event.target.name;
        switch (name) {
            case "name":
                let inputName = event.target.value;
                break;

            default:
                break;
        }
    };
    useEffect(() => {
        getUser();
    }, []);
    return (
        <form>
            <Row className="mb-3">
                <div className="col-lg-6">
                    <label htmlFor="editName" className="form-label">
                        Full name
                    </label>
                    <input
                        onChange={handleChange}
                        type="text"
                        className="form-control"
                        id="editName"
                        value={user.name}
                        name="name"
                    />
                </div>
                <div className="col-lg-6">
                    <label htmlFor="editUsername" className="form-label">
                        Email
                    </label>
                    <input
                        onChange={handleChange}
                        type="text"
                        className="form-control"
                        id="editUsername"
                        value={user.username}
                        name="email"
                    />
                </div>
            </Row>

            <Row className="mb-3">
                <div className="col-lg-12">
                    <label htmlFor="editEmail" className="form-label">
                        Email
                    </label>
                    <input
                        onChange={handleChange}
                        type="text"
                        className="form-control"
                        id="editEmail"
                        value={user.email}
                        name="phone"
                    />
                </div>
            </Row>
        </form>
    );
}
