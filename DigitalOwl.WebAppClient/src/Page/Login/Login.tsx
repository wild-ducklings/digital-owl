import React from "react";
import {makeStyles} from "@material-ui/styles";
import {Button, Card, createStyles, Theme} from "@material-ui/core";
import {Form, FormikBag, FormikErrors, FormikProps, withFormik} from "formik";
import {useDispatch, useSelector} from "react-redux";
import {DispatchType, StateType} from "../../Store/store";
import {FormikField} from "../../Component/Formik/Field";
import {AuthActions, fetchRegisterUser} from "./AuthSlice";
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
            maxWidth: 400,
            margin: 10,
        },
    }),
);

export interface FormValues {
    UserName: string;
    Password: string;
}

const initialValues: FormValues = {
    UserName: "",
    Password: ""
};

interface OtherProps {
    message: string;
}


const InnerForm = (props: OtherProps & FormikProps<FormValues>) => {

    const {touched, errors, isSubmitting, message} = props;


    return (
        <Form onSubmit={props.handleSubmit}>
            <h1>{message}</h1>
            <FormikField type="input" name="UserName" label="UserName"/>

            <FormikField type="password" name="Password" label="Password"/>

            <Button
                type="submit"
                color="secondary"
                variant="contained"
            >
                Submit
            </Button>
        </Form>
    );
};

// The type of props MyForm receives
interface MyFormProps {
    initialEmail?: string;
    message: string; // if this passed all the way through you might do this or make a union type
    dispatch: DispatchType,
    logina: boolean
}

// Wrap our form with the withFormik HoC
const MyForm = withFormik<MyFormProps, FormValues>({
    // Transform outer props into form values
    mapPropsToValues: props => {
        return {
            UserName: props.initialEmail || '',
            Password: '',
        };
    },
    // Add a custom validation function (this can be async too!)
    validate: (values: FormValues) => {
        let errors: FormikErrors<any> = {};
        if (!values.UserName) {
            errors.email = 'Required';
        } else if (values.UserName === "abc@a.a") {
            errors.email = 'Invalid email address';
        }
        return errors;
    },

    handleSubmit: async (values, props: FormikBag<MyFormProps, FormValues>) => {
        console.log("aaaaa");
        // alert(JSON.stringify(values));
        await props.props.dispatch(fetchRegisterUser(values));
        if (props.props.logina) {
            props.props.dispatch(AuthActions.login(localStorage.getItem("token")));
        }


    },
})(InnerForm);


export const LoginPage: React.FC<Props> = () => {
    const logina = useSelector((state: StateType) => state.AuthReducer.login);
    const classes = useStyles();
    const dispatch = useDispatch();
    return (
        <div className={classes.loginRoot}>
            <Card className={classes.card}>
                <MyForm message="Sign up" dispatch={dispatch} logina={logina}/>
                {logina && <Redirect to={"/"}/>}
            </Card>
        </div>
    );
}