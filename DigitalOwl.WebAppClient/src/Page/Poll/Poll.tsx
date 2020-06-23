import React, {useState} from "react";
import {Create} from "@material-ui/icons";
import {Card, createStyles, Theme, Button, Icon, List, ListItem} from "@material-ui/core";
import {makeStyles} from "@material-ui/styles";
import AddCircleIcon from '@material-ui/icons/AddCircle';
import EditIcon from '@material-ui/icons/Edit';


const PollStyle = makeStyles((theme: Theme) => createStyles({
    root: {
        display: "flex",
        flexDirection: "column"
    },
    header: {
        margin: "15px"
    },
    box: {
        display: "flex",
        alignContent: "space-between",
        flexDirection: "row"
    },
    info: {
        display: "flex",
        justifyContent: "center",
        background: theme.palette.grey["700"],
        fontSize: 17
    },
    space: {
        flexGrow: 1
    },
    list: {
        display: "flex",
        justifyContent: "center",
        flexDirection: "column"
    }

}))

export const Poll: React.FC<{}> = () => {
    const generalStyle = PollStyle();
    const [isShownAddInfo, setIsShownAddInfo] = useState(false);
    const [isShownUpdateInfoA, setIsShownUpdateInfoA] = useState(false);
    const [isShownUpdateInfoB, setIsShownUpdateInfoB] = useState(false);

    const addInfo =
        <Card className={generalStyle.info}>
            Add a new quiz.
        </Card>

    const updateInfo =
        <Card className={generalStyle.info}>
            Edit Quiz.
        </Card>

    return <div className={generalStyle.root}>
        <Card className={generalStyle.box}>
            <h1 className={generalStyle.header}> Quizes </h1>
            <div className={generalStyle.space}></div>
            <Button onMouseEnter={() => setIsShownAddInfo(true)}
                    onMouseLeave={() => setIsShownAddInfo(false)}>
                <AddCircleIcon/>
            </Button>
        </Card>
        {isShownAddInfo && addInfo}
        <List className={generalStyle.list}>

            <Card className={generalStyle.box}>
                <h4 className={generalStyle.header}> QuizA </h4>
                <div className={generalStyle.space}></div>
                <Button onMouseEnter={() => setIsShownUpdateInfoA(true)}
                        onMouseLeave={() => setIsShownUpdateInfoA(false)}>
                    <EditIcon/>
                </Button>
            </Card>
        {isShownUpdateInfoA && updateInfo}

            <Card className={generalStyle.box}>
                <h4 className={generalStyle.header}> QuizB </h4>
                <div className={generalStyle.space}></div>
                <Button onMouseEnter={() => setIsShownUpdateInfoB(true)}
                        onMouseLeave={() => setIsShownUpdateInfoB(false)}>
                    <EditIcon/>
                </Button>
            </Card>
            {isShownUpdateInfoB && updateInfo}


        </List>
    </div>;
}