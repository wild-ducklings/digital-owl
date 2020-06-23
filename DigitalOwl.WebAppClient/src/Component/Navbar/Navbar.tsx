import React from "react";
import {AppBar, createStyles, IconButton, Theme, Toolbar, Typography} from "@material-ui/core";
import {makeStyles} from "@material-ui/styles";
import MenuIcon from "@material-ui/icons/Menu";
import {useDispatch, useSelector} from "react-redux";
import {toggleDrawerExported} from "../Sidebar/Sidebar";
import {DropdownUserMenu} from "../DropdownMenu/DropdownUserMenu";
import {StateType} from "../../Store/store";

const UseStyles = makeStyles((theme: Theme) =>
    createStyles({
        loginRoot: {
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
    const loginState = useSelector((state: StateType) => state.AuthReducer.login);
    const classes = UseStyles();

    const dispatch = useDispatch();

    const toggleSidebar = toggleDrawerExported(dispatch)(true);

    return <AppBar position={"static"} className={classes.loginRoot}>
        <Toolbar>
            {loginState && <IconButton edge={"start"} onClick={toggleSidebar} children={<MenuIcon/>}/>}
            <Typography variant={"h6"} className={classes.title}>
                {props.title}
            </Typography>
            <DropdownUserMenu/>
        </Toolbar>
    </AppBar>;
};