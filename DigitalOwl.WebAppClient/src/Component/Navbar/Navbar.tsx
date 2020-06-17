import React from "react";
import {AppBar, createStyles, IconButton, Theme, Toolbar, Typography} from "@material-ui/core";
import {makeStyles} from "@material-ui/styles";
import MenuIcon from "@material-ui/icons/Menu";
import AccountCircleIcon from '@material-ui/icons/AccountCircle';
import {useDispatch} from "react-redux";
import {toggleDrawerExported} from "../Sidebar/Sidebar";
import {DropdownUserMenu} from "../DropdownMenu/DropdownUserMenu";

const UseStyles = makeStyles((theme: Theme) =>
    createStyles({
        root: {
            width: "100%",
        },
        title: {
            flexGrow: 1,
            marginLeft: "5px",
        }
    }),
);

interface Props {
    title: string
}

export const Navbar: React.FC<Props> = (props) => {

    const classes = UseStyles();

    const dispatch = useDispatch();


    return <AppBar position={"static"} className={classes.root}>
        <Toolbar>
            <IconButton edge={"start"} onClick={toggleDrawerExported(dispatch)(true)}>
                <MenuIcon/>
            </IconButton>
            <Typography variant={"h6"} className={classes.title}>
                {props.title}
            </Typography>
            <DropdownUserMenu />
        </Toolbar>
    </AppBar>;
};