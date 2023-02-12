import "../node_modules/bootstrap/dist/css/bootstrap.min.css";
import Navbar from "./layout/Navbar";
import Home from "./pages/Home";
import AddUserForm from "./pages/user/AddUserForm";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import ViewUser from "./pages/user/ViewUser";
function App() {
    return (
        <div className="App">
            <Router>
                <Navbar />
                <Routes>
                    <Route
                        path={"/"}
                        element={
                            <>
                                <AddUserForm />
                                <Home />
                            </>
                        }
                    />
                    <Route path={"/view/:id"} element={<ViewUser />} />
                </Routes>
            </Router>
        </div>
    );
}

export default App;
