import React from "react";
import {List} from "@material-ui/core";
import {ModelGroup} from "../../Model/ModelGroup";
import {useSelector} from "react-redux";
import {StateType} from "../../Store/store";
import {GroupListItem} from "./GroupListItem";

export const GroupList: React.FC<{}> = () => {
    const groupArray = useSelector((state: StateType) => state.GroupReducer.group);

    return (
        <List>
            {(groupArray !== undefined && groupArray !== []) &&
            groupArray.map((g: ModelGroup) => <GroupListItem g={g}/>)
            }
        </List>);

};