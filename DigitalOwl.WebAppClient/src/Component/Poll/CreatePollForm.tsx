import {Form, FormikBag, FormikErrors, FormikProps, withFormik} from "formik";
import {makeStyles} from "@material-ui/styles";
import {Button, createStyles, Theme} from "@material-ui/core";
import React from "react";
import {ModelCreatePoll} from "../../Model/ModelPoll";
import {DispatchType} from "../../Store/store";
import {CreatePollThunk} from "../../Page/Poll/PollSlice";
import {FormikField} from "../Formik/Field";

const PollFormStyle = makeStyles((theme: Theme) =>
    createStyles({
        root: {
            margin: "15px"
        },
        form: {
            flexGrow: 1,
            justifyContent: "center",
            display: "flex",
            alignItems: "center",
            margin: "15px"
        }
    }),
);

type PollPropType =  FormikProps<ModelCreatePoll>;


export const CreatePollForm: React.FC<PollPropType> = (props: PollPropType) => {
    const style = PollFormStyle();


    return (<Form className={style.root}>

        <FormikField name={"Title"} label={"Title"}/>

        <div className={style.form}>
            <Button
                type="submit"
                color="primary"
                variant="contained">
                Submit
            </Button>
        </div>
    </Form>);
}

interface PollFormProps {
    dispatch: DispatchType
}


export const PollForm = withFormik<PollFormProps, ModelCreatePoll>({

    mapPropsToValues: props => {
        return {
            Title: '',
        };

    },

    validate: (values: ModelCreatePoll) => {
        let errors: FormikErrors<any> = {};
        if (!values.Title) {
            errors.Title = 'Required';
        }
        return errors;
    },

    handleSubmit: async (values: ModelCreatePoll, {props}: FormikBag<PollFormProps, ModelCreatePoll>) => {
        const {dispatch} = props;

        await dispatch(CreatePollThunk(values));
    },
})(CreatePollForm);
