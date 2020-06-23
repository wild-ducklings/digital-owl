import React from "react";
import {Button, Card, CardActions, CardContent, createStyles, Theme, Typography} from "@material-ui/core";
import {makeStyles} from "@material-ui/styles";
import {BrowserRouter as Router, Redirect, Route, Switch} from "react-router-dom";
import {LoginPage} from "../Page/Login/Login";
import {Navbar} from "../Component/Navbar/Navbar";
import {Sidebar} from "../Component/Sidebar/Sidebar";
import {LandingPage} from "../Page/Landing/LandingPage";
import {Poll} from "../Page/Poll/Poll";

const UseStyles = makeStyles((theme: Theme) =>
    createStyles({
        loginRoot: {
            flexGrow: 1,
            flexDirection: "column",
            background: theme.palette.background.default,
            justifyContent: "center",
            // display: "flex",
            alignItems: "center"
        },
        title: {
            fontSize: 17,
        }

    }),
);

export default () => {
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
                <Route path={"/"}>
                    <LandingPage/>
                </Route>
            </Switch>
        </Router>
    </div>
        ;
}