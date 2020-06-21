import React from "react";
import {IconButton, Menu, MenuItem} from "@material-ui/core";
import AccountCircleIcon from "@material-ui/icons/AccountCircle";
import {useDispatch, useSelector} from "react-redux";
import {AuthActions} from "../../Page/Login/AuthSlice";
import {DispatchType, StateType} from "../../Store/store";
import {Redirect} from "react-router-dom";
import {DropdownUserMenuActions} from "./DropdownUserMenuSlice";

export interface MenuItems {
    name: string,
    callbackFunc: any,
}

interface Props {
    // menuItems: [MenuItems],
}

// i couldnt use Redux cause Redux dont work well with HTMLElement
export const DropdownUserMenu: React.FC<Props> = () => {
    const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
    const dispatch = useDispatch<DispatchType>();
    const loginState = useSelector((state: StateType) => state.AuthReducer.login);
    const loginPopState = useSelector((state: StateType) => state.DropdownUserMenuReducer.isOpen);

    const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };
    const logout = () => {
        dispatch(AuthActions.logout());
    };
    const login = () => {
        dispatch(DropdownUserMenuActions.openSidebar());
    };

    if (loginPopState) {
        return <Redirect to="/login" push/>;
    }

    return <div>
        <IconButton onClick={handleClick}>
            <AccountCircleIcon/>
        </IconButton>

        <Menu
            id="simple-menu"
            anchorEl={anchorEl}
            keepMounted
            open={Boolean(anchorEl)}
            onClose={handleClose}
        >
            <MenuItem onClick={handleClose}>Profile</MenuItem>
            <MenuItem onClick={handleClose}>My account</MenuItem>
            {loginState ? <MenuItem onClick={logout}>Logout</MenuItem> :
                <MenuItem onClick={login}>Login</MenuItem>}
        </Menu>
    </div>;
};