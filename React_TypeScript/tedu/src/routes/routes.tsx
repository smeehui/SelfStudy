import {config} from "~/config";
import Login from "~/pages/Auth/Login";
import Admin from "~/pages/Admin/Admin";
import {MainLayout} from "~/layouts";
import {ReactElement} from "react";

type Route = {
    element: ()=>ReactElement,
    path: string,
    layout?: ({children}) => ReactElement;
}

const publicRoutes: Route[] = [
    {element: Login,path: config.routes.login, layout: MainLayout},
    {element: Admin,path: config.routes.dashboard,layout: MainLayout},
    {element: Login,path: "*", layout: MainLayout},
]

export default {publicRoutes}