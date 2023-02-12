import axios from "axios";
import React, { memo, useEffect, useState } from "react";
import { Button, Card, CardGroup, CardImg, Row } from "react-bootstrap";
import CardHeader from "react-bootstrap/esm/CardHeader";
import { Link, useParams } from "react-router-dom";

function ViewUser({ userId }) {
    let { id } = useParams();
    if (!id) {
        id = userId;
    }
    console.log(id);
    const [user, setUser] = useState({
        name: "",
        username: "",
        email: "",
    });
    let loadUser = async () => {
        let rs = await axios.get(`http://localhost:8080/users/${id}`);
        setUser(rs.data);
    };

    useEffect(() => {
        loadUser();
    }, [id]);

    return (
        <CardGroup className="card-deck">
            <Card>
                <CardHeader>Customer information</CardHeader>
                <CardImg variant="top" src="holder.js/100x180/" alt="" />
                <Row className="card-body">
                    <div className="card-title h4">{user.name}</div>
                    <Row className="card-text">
                        <div className="col-lg-6">
                            <span className="col-lg-3">Email:</span>
                            <p>{user.email}</p>
                        </div>
                        <div className="col-lg-6">
                            <span className="col-lg-3">Username:</span>
                            <p>{user.username}</p>
                        </div>
                    </Row>
                </Row>
                <div className="card-footer">
                    <Link className="text-decoration-none">
                        <Button variant="outline-primary mx-1">
                            Edit info
                        </Button>
                    </Link>

                    <Link to={"/"} className="text-decoration-none">
                        <Button variant="outline-secondary">
                            Back to list
                        </Button>
                    </Link>
                </div>
            </Card>
        </CardGroup>
    );
}
export default memo(ViewUser);
