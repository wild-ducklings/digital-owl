import React from "react";
import {ModelGroup} from "../../Model/ModelGroup";
import {Card, createStyles, ListItem, Theme} from "@material-ui/core";
import EditIcon from "@material-ui/icons/Edit";
import {makeStyles} from "@material-ui/styles";

const useStyle = makeStyles((theme: Theme) =>
    createStyles(
        {
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
export const GroupListItem: React.FC<{ g: ModelGroup }> = ({g}) => {
    const classes = useStyle();

    return (
        <Card className={classes.item}>
            <ListItem key={g.id} className={classes.items}>
                {g.name}
                < EditIcon/>
            </ListItem>
        </Card>
    )
};