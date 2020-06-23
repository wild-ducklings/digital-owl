import React from "react";
import {makeStyles} from "@material-ui/styles";
import {Button, Card, createStyles, List, ListItem, Theme} from "@material-ui/core";
import {useDispatch, useSelector} from "react-redux";
import {DispatchType, StateType} from "../../Store/store";
import {Redirect} from "react-router-dom";
import {GroupGetAllThunk} from "./GroupSlice";
import {ModelGroup} from "../../Model/ModelGroup";

interface Props {

}

const useStyle = makeStyles((theme: Theme) =>
    createStyles(
        {
            root: {
                display: "flex",
                // alignContent: "center",
                alignItems: "center",
                flexDirection: "column"
            },
            a: {
                flex: 1,
                flexDirection: "row",
                // flex
                background: theme.palette.success.light,
                margin: "10px",
                padding: "10px"
            }
        })
);

export const GroupPage: React.FC<Props> = (props: Props) => {
    const classes = useStyle();
    const guardState = useSelector((state: StateType) => state.AuthReducer.login);
    const dispatch = useDispatch<DispatchType>();
    const groupArray = useSelector((state: StateType) => state.GroupReducer.group);

    const {} = props;
    const a = async () => {
        await dispatch(GroupGetAllThunk());
    };

    return (
        <div className={classes.root}>

            {!guardState && <Redirect to={"/"} push/>}
            <div className={classes.a}>
                <Button color={"primary"} variant="contained" onClick={a}>
                    Click
                </Button>
                <h1> test</h1>
            </div>
            {groupArray != [] &&
            <Card>
                <List>
                    {groupArray.map((g: ModelGroup) => {
                        return (
                            <ListItem key={g.id}>
                                {g.name}
                            </ListItem>
                        );
                    })}
                </List>
            </Card>
            }
        </div>
    );
}