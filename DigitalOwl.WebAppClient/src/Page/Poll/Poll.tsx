import React, {useEffect} from "react";
import {Button, Card, createStyles, List, Theme} from "@material-ui/core";
import {makeStyles} from "@material-ui/styles";
import AddCircleIcon from '@material-ui/icons/AddCircle';
import {useDispatch, useSelector} from "react-redux";
import {DispatchType, StateType} from "../../Store/store";
import {GetAllPollThunk, PollAction, PollEditInfo} from "./PollSlice";
import {SinglePoll} from "./SinglePoll";
import {Redirect} from "react-router-dom";

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
        background: theme.palette.grey["400"],
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
    const PollEditInfoState = useSelector((state: StateType) => state.PollReducer.EditInfoPopup);
    const PollAddState = useSelector((state: StateType) => state.PollReducer.CreatePoll);

    const addInfo =
        <Card className={generalStyle.info}>
            Add a new quiz.
        </Card>;

    useEffect(() => {
        dispatch(GetAllPollThunk());
        dispatch(PollAction.NegateCreatedPoll())
    }, []);

    if (PollAddState)
        return <Redirect to={"/create_quiz"}/>

    return (<div className={generalStyle.root}>
        <Card className={generalStyle.box}>
            <h1 className={generalStyle.header}> Quizzes </h1>
            <div className={generalStyle.space}> </div>
            <Button onMouseEnter={() => dispatch(PollAction.ShowAddInfo())}
                    onMouseLeave={() => dispatch(PollAction.HideAddInfo())}
                    onClick={() => dispatch(PollAction.CreatePollRedirect())}>
                <AddCircleIcon/>
            </Button>
        </Card>
        {PollAddInfoState && addInfo}

        {PollEditInfoState !== [] &&
        <List>
            {PollEditInfoState.map((x: PollEditInfo) => <SinglePoll PollEditInfo={x}/>)}
        </List>}
    </div>);
};