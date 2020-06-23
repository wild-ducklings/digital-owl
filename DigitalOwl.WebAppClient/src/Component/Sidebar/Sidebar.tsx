import React, {Dispatch} from "react";
import {useDispatch, useSelector} from "react-redux";
import {DispatchType, StateType} from "../../Store/store";
import {createStyles, List, ListItem, ListItemIcon, ListItemText, SwipeableDrawer, Theme} from "@material-ui/core";
import AddIcon from '@material-ui/icons/Add';
import {SidebarActions} from "./SidebarSlice";
import {makeStyles} from "@material-ui/styles";

const UseStyles = makeStyles((theme: Theme) =>
    createStyles({
        list: {
            width: 250,
        },
    }),
);

interface Props {

}

export const toggleDrawerExported =
    (dispatch: Dispatch<any>) => (open: boolean) =>
        (event: React.KeyboardEvent | React.MouseEvent) => {
            if (
                event &&
                event.type === 'keydown' &&
                ((event as React.KeyboardEvent).key === 'Tab' ||
                    (event as React.KeyboardEvent).key === 'Shift')
            ) {
                return;
            }

            if (open) {
                dispatch(SidebarActions.openSidebar())
            } else {
                dispatch(SidebarActions.closeSidebar())
            }
        };

export const Sidebar: React.FC<Props> = () => {
    const classes = UseStyles();

    const dispatch = useDispatch<DispatchType>();
    const isOpen = useSelector((state: StateType) => state.SidebarReducer.isOpen);
    const loginState = useSelector((state: StateType) => state.AuthReducer.login);

    const toggleDrawer = toggleDrawerExported(dispatch);
    return <SwipeableDrawer
        anchor={"left"}
        open={isOpen}
        onClose={toggleDrawer(false)}
        onOpen={toggleDrawer(true)}
    >
        <div
            className={classes.list}
            role={"presentation"}
            onKeyDown={toggleDrawer(false)}
            onClick={toggleDrawer(false)}
        >
            <List>
                <ListItem onClick={()=>{console.log("aaaaa")}} button key={"Add"}>
                    <ListItemIcon>
                        <AddIcon/>
                    </ListItemIcon>
                    <ListItemText primary={"Add"}/>
                </ListItem>
            </List>
        </div>
    </SwipeableDrawer>;
};