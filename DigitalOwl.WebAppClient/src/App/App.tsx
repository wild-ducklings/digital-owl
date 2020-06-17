import React from "react";
import {createStyles, Theme} from "@material-ui/core";
import {makeStyles} from "@material-ui/styles";
import {BrowserRouter as Router, Route, Switch} from "react-router-dom";
import {LoginPage} from "../Page/Login/Login";
import {Navbar} from "../Component/Navbar/Navbar";
import {Sidebar} from "../Component/Sidebar/Sidebar";

const UseStyles = makeStyles((theme: Theme) =>
    createStyles({
        root: {
            flexGrow: 1,
            flexDirection: "column",
            background: theme.palette.background.default,
            justifyContent: "center",
            display: "flex",
            alignItems: "center"
        }
    }),
);

export default () => {
    const classes = UseStyles();
    return <div className={classes.root}>
        <Navbar title={"Digital Owl"}/>
        <Sidebar/>
        <Router>
            <Switch>
                <Route path={"/login"}>
                    <LoginPage/>
                </Route>
                <Route path={"/"}>

                </Route>
            </Switch>
        </Router>
    </div>;
}