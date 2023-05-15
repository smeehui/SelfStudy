import React from 'react'
import {HeaderDesktop, HeaderMobile, Sidebar} from "~/components";

function MainLayout({children}) {
    return (
        <div className="page-wrapper">
            <HeaderMobile/>
            <Sidebar/>
            <div className="page-container">
                <HeaderDesktop/>
                <div className="main-content">
                    {children}
                </div>
            </div>
        </div>
    )
}

export default MainLayout
