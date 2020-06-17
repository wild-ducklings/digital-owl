import React from "react";
import {IconButton, Menu, MenuItem} from "@material-ui/core";
import AccountCircleIcon from "@material-ui/icons/AccountCircle";

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

    const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };

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
            <MenuItem onClick={handleClose}>Logout</MenuItem>
        </Menu>
    </div>;
};