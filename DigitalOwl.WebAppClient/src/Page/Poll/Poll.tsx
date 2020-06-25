import React from "react";
import {Button, Card, createStyles, List, Theme} from "@material-ui/core";
import {makeStyles} from "@material-ui/styles";
import AddCircleIcon from '@material-ui/icons/AddCircle';
import {useDispatch, useSelector} from "react-redux";
import {DispatchType, StateType} from "../../Store/store";
import {PollAction} from "./PollSlice";
import {SinglePoll} from "../../Component/SinglePoll";

export const PollStyle = makeStyles((theme: Theme) => createStyles({
    root: {
        display: "flex",
        justifyContent: "center",
        flexDirection: "column"
    },
    header: {
        margin: "15px"
    },
    box: {
        display: "flex",
        alignContent: "space-between",
        flexDirection: "row",
    },
    info: {
        display: "flex",
        justifyContent: "center",
        background: theme.palette.grey["700"],
        fontSize: 17
    },
    space: {
        flexGrow: 1
    }

}));

export const Poll: React.FC<{}> = () => {
    const generalStyle = PollStyle();

    const dispatch = useDispatch<DispatchType>();
    const PollAddInfoState = useSelector((state: StateType) => state.PollReducer.AddInfoPopup);

    const addInfo =
        <Card className={generalStyle.info}>
            Add a new quiz.
        </Card>;

    return (<div className={generalStyle.root}>
        <Card className={generalStyle.box}>
            <h1 className={generalStyle.header}> Quizzes </h1>
            <div className={generalStyle.space}> </div>
            <Button onMouseEnter={() => dispatch(PollAction.ShowAddInfo())}
                    onMouseLeave={() => dispatch(PollAction.HideAddInfo())}>
                <AddCircleIcon/>
            </Button>
        </Card>
        {PollAddInfoState && addInfo}


        <List>
            <SinglePoll Poll={{Id: 0, Title: "QuizA", Points: 3}}/>
            <SinglePoll Poll={{Id: 1, Title: "QuizB", Points: 3}}/>
        </List>
    </div>);
};