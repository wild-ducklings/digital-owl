import React from "react";
import {Form, FormikBag, FormikErrors, FormikProps, withFormik} from "formik";
import {FormikField} from "../Formik/Field";
import {Button, createStyles, Theme} from "@material-ui/core";
import {DispatchType} from "../../Store/store";
import {fetchRegisterUser} from "../../Page/Login/AuthSlice";
import {makeStyles} from "@material-ui/styles";
import {LoginUser} from "../../Model/LoginUser";

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        form: {
            flexGrow: 1,
            justifyContent: "center",
            display: "flex",
            alignItems: "center"
        }
    }),
);


interface OtherProps {
    message: string;
}

type PropType = OtherProps & FormikProps<LoginUser>;

const InnerForm: React.FC<PropType> = (props: PropType) => {
    const classes = useStyles();

    const {errors, isSubmitting, message} = props;


    return (
        <Form onSubmit={props.handleSubmit}>

            <h1 className={classes.form}>{message}</h1>

            <FormikField type="input" name="UserName" label="UserName"/>

            <FormikField type="password" name="Password" label="Password"/>

            <div className={classes.form}>
                <Button
                    type="submit"
                    color="primary"
                    variant="contained">
                    Submit
                </Button>
            </div>

        </Form>
    );
};

// The type of props MyForm receives
interface MyFormProps {
    dispatch: DispatchType,
    message: string;
}

// Wrap our form with the withFormik HoC
export const MyForm = withFormik<MyFormProps, LoginUser>({
    // Transform outer props into form values
    mapPropsToValues: props => {
        return {
            UserName: '',
            Password: '',
        };
    },
    // Add a custom validation function (this can be async too!)
    validate: (values: LoginUser) => {
        let errors: FormikErrors<any> = {};
        if (!values.UserName) {
            errors.email = 'Required';
        } else if (values.UserName === "abc@a.a") {
            errors.email = 'Invalid email address';
        }
        return errors;
    },

    handleSubmit: async (values: LoginUser, {props}: FormikBag<MyFormProps, LoginUser>) => {
        const {dispatch} = props;

        await dispatch(fetchRegisterUser(values));

    },
})(InnerForm);
