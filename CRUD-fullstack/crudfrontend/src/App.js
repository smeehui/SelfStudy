import "../node_modules/bootstrap/dist/css/bootstrap.min.css";
import Navbar from "./layout/Navbar";
import Home from "./pages/Home";
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
