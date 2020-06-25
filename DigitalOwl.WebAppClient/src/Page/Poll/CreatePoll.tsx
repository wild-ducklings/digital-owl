import React, {useEffect} from "react";
import {PollForm} from "../../Component/Poll/CreatePollForm";
import {useDispatch, useSelector} from "react-redux";
import {DispatchType, StateType} from "../../Store/store";
import {Redirect} from "react-router-dom";
import {PollAction} from "./PollSlice";

export const CreatePoll: React.FC<{}> = () => {
    const dispatch = useDispatch<DispatchType>();
    const PollCreatedState= useSelector((state: StateType) => state.PollReducer.CreatedPoll);

    useEffect( () =>
    {dispatch(PollAction.NegateCreatePoll());})

    if(PollCreatedState)
        return <Redirect to={"/quizzes"}/>

    return <PollForm dispatch = {dispatch}/>;

}