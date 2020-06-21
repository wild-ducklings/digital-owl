import {Button, Card, CardActions, CardContent, createStyles, Theme, Typography} from "@material-ui/core";
import {Redirect} from "react-router-dom";
import React from "react";
import {makeStyles} from "@material-ui/styles";

const UseStyles = makeStyles((theme: Theme) =>
    createStyles({
        title: {
            fontSize: 17,
        }

    }),
);

export const LandingPage = () => {
    const classes = UseStyles();
    return <Card>
        <CardContent>
            <Typography className={classes.title} color="textSecondary" gutterBottom>
                To use this service you must login
            </Typography>
        </CardContent>
        <CardActions>
            <Button size="small" onClick={() => {
                alert("xd")
            }}>Learn More</Button>
            {false && <Redirect to={"login"}/>}
        </CardActions>
    </Card>;
}