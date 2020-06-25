import React, {useEffect} from "react";
import {useDispatch} from "react-redux";
import {Button, Card, ListItem} from "@material-ui/core";
import EditIcon from "@material-ui/icons/Edit";
import {DispatchType} from "../../Store/store";
import {PollStyle} from "./Poll";
import {PollAction, PollEditInfo} from "./PollSlice";

export const SinglePoll: React.FC<{ PollEditInfo: PollEditInfo }> = (args) => {
    const dispatch = useDispatch<DispatchType>();
    const generalStyle = PollStyle();
    const {Poll, EditInfoState} = args.PollEditInfo;
    useEffect(() => {
        console.log(Poll);
    }, []);

    return <div>
        <Card className={generalStyle.box}>
            <ListItem key={Poll.id}>
                <h4 className={generalStyle.header}> {Poll.title} </h4>
                <div className={generalStyle.space}> </div>
                <Button
                    onMouseEnter={() => {
                        dispatch(PollAction.ShowEditInfo(Poll.id))
                    }}
                    onMouseLeave={() => {
                        dispatch(PollAction.HideEditInfo(Poll.id))
                    }}>
                    <EditIcon/>
                </Button>
            </ListItem>
        </Card>

        {EditInfoState &&
        <Card className={generalStyle.info}>
            Edit {Poll.title}.
        </Card>}
    </div>
}