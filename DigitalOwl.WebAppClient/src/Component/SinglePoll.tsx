import React from "react";
import {ModelPoll} from "../Model/ModelPoll";
import {useDispatch, useSelector} from "react-redux";
import {DispatchType, StateType} from "../Store/store";
import {Button, Card} from "@material-ui/core";
import {PollAction} from "../Page/Poll/PollSlice";
import EditIcon from "@material-ui/icons/Edit";
import {PollStyle} from "../Page/Poll/Poll";

export const SinglePoll: React.FC<{Poll: ModelPoll}> = (args) => {
    const PollEditInfoState = useSelector((state: StateType) => state.PollReducer.EditInfoPopup);
    const dispatch = useDispatch<DispatchType>();
    const generalStyle = PollStyle();
    const id = args.Poll.Id;

    const updateInfo = ({Title}: ModelPoll) =>
        <Card className={generalStyle.info}>
            Edit {Title}.
    </Card>

    return <div>
        <Card className={generalStyle.box}>
    <h4 className={generalStyle.header}> {args.Poll.Title} </h4>
        <div className={generalStyle.space}> </div>
        <Button onMouseEnter={() => dispatch(PollAction.ShowEditInfo(id))}
    onMouseLeave={() => dispatch(PollAction.HideEditInfo(id))}>
    <EditIcon/>
    </Button>
    </Card>

    {PollEditInfoState[id].EditInfoState && updateInfo(args.Poll)}
    </div>
}