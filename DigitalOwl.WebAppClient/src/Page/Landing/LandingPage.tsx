import {Button, Card, CardActions, CardContent, createStyles, Theme, Typography} from "@material-ui/core";
import {Redirect} from "react-router-dom";
import React from "react";
import {makeStyles} from "@material-ui/styles";
import api from "Services/Base/Api";

const UseStyles = makeStyles((theme: Theme) =>
    createStyles({
        loginRoot: {
            flexGrow: 1,
            flexDirection: "column",
            justifyContent: "center",
            display: "flex",
            alignItems: "center"
        },
        title: {
            fontSize: 17,
        }

    }),
);

export const LandingPage = () => {
    const classes = UseStyles();

    const add = async () => {
        const res = await api({
            method: "get",
            url: "/group",
            data: {
                name: "test"
            }
        }).catch((e) => console.log("test", e));
        console.log(res);
    };

    return (
        <div className={classes.loginRoot}>
            {false && <Redirect to={"/login"}/>}
            <Card>
                <CardContent>
                    <Typography className={classes.title} color="textSecondary" gutterBottom>
                        To use this service you must login
                    </Typography>
                </CardContent>
                <CardActions>
                    <Button size="small" onClick={add}>
                        Learn More
                    </Button>
                </CardActions>
            </Card>
        </div>
    );
}