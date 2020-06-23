import React from "react";
import {makeStyles} from "@material-ui/styles";
import {Card, createStyles, Theme} from "@material-ui/core";
import {useDispatch, useSelector} from "react-redux";
import {DispatchType, StateType} from "../../Store/store";
import {MyForm} from "../../Component/LoginForm/LoginForm";
import {Redirect} from "react-router-dom";

interface Props {

}

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        loginRoot: {
            flexGrow: 1,
            background: theme.palette.background.default,
            justifyContent: "center",
            display: "flex",
            alignItems: "center"
        },
        card: {
            margin: "10px",
            padding: "20px"
        },
    }),
);


export const LoginPage: React.FC<Props> = ({}: Props) => {
    const classes = useStyles();

    const guardState = useSelector((state: StateType) => state.AuthReducer.login);

    const dispatch: DispatchType = useDispatch(); // TODO Find way to move it to LoginForm

    return (
        <div className={classes.loginRoot}>

            {guardState && <Redirect to={"/"} push/>}

            <Card className={classes.card}>
                <MyForm message="Sign up" dispatch={dispatch}/>
            </Card>
        </div>
    );
}