import React from "react";
import {createStyles, Theme} from "@material-ui/core";
import {makeStyles} from "@material-ui/styles";
import {Navbar} from "./Navbar";
import {Sidebar} from "./Sidebar";

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
    </div>;
}