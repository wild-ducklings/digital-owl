import React from "react";
import {createStyles, Theme} from "@material-ui/core";
import {makeStyles} from "@material-ui/styles";
import {Poll} from "../Page/Poll/Poll";
import {LoginPage} from "Page/Login/Login";
import {Navbar} from "Component/Navbar/Navbar";
import {Sidebar} from "Component/Sidebar/Sidebar"
import {LandingPage} from "Page/Landing/LandingPage";
import {GroupPage} from "Page/Group/GroupPage";

const UseStyles = makeStyles(
    (theme: Theme) =>
        createStyles({
            loginRoot: {
                background: theme.palette.background.default,
            },
            title: {
                fontSize: 17,
            },
        }),
);

export const App = () => {

    const classes = UseStyles();

    return <div className={classes.loginRoot}>
        <Router>
            <Navbar title={"Digital Owl"}/>
            <Sidebar/>

            <Switch>
                <Route path={"/login"}>
                    <LoginPage/>
                </Route>
                <Route path={"/czygonciarzapojebalo"}>
                    <Poll/>
                </Route>
                <Route path={"/group"}>
                    <GroupPage/>
                </Route>
                <Route path={"/"}>
                    <LandingPage/>
                </Route>
            </Switch>
        </Router>
    </div>;
}