import './App.css'
import React from "react";
import {Route, Routes} from "react-router";
import {routes} from "~/routes";

function App() {
    return (
        <Routes>
            {routes.publicRoutes.map( (r)=>{
                const Element = r.element;
                const Layout = r.layout;
                return <Route key={r.path} path = {r.path} element = {<Layout><Element/></Layout>}/>;
            })}
        </Routes>
    )
}

export default App
