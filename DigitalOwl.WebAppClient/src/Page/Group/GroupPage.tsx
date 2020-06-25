import React, {useEffect} from "react";
import {makeStyles} from "@material-ui/styles";
import {Box, Button, Container, createStyles, Theme, Typography} from "@material-ui/core";
import {useDispatch, useSelector} from "react-redux";
import {DispatchType, StateType} from "../../Store/store";
import {Redirect} from "react-router-dom";
import {GroupGetAllThunk} from "./GroupSlice";
import AddCircleIcon from '@material-ui/icons/AddCircle';
import {GroupList} from "./GroupList";

interface Props {

}

const useStyle = makeStyles((theme: Theme) =>
    createStyles(
        {
            root: {
                display: "flex",
                alignItems: "center",
                flexDirection: "column"
            },
            header: {
                display: "flex",
                flexDirection: "row",
                justifyContent: "space-between",
                alignItems: "flex-end",
                // background: theme.palette.success.light,
                margin: "10px"
            },
            item: {
                margin: "5px"
            },
            items: {
                display: "flex",
                flexDirection: "row",
                justifyContent: "space-between",
            }
        })
);

export const GroupPage: React.FC<Props> = (props: Props) => {
    const classes = useStyle();
    const dispatch = useDispatch<DispatchType>();

    const {} = props;

    useEffect(() => {
        dispatch(GroupGetAllThunk());
    }, []);


    const guardState = useSelector((state: StateType) => state.AuthReducer.login);
    if (!guardState) {
        return <Redirect to={"/"} push/>;
    }

    return (
        <Box className={classes.root}>

            <Container maxWidth={"xl"} className={classes.header}>
                <Typography variant={"h4"}>Group</Typography>
                <Button>
                    <AddCircleIcon/>
                </Button>
            </Container>
            <Container maxWidth={"xl"}>
                <GroupList/>
            </Container>
        </Box>
    );
}