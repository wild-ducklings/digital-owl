import {ModelPoll} from "../../Model/ModelPoll";
import {createSlice} from "@reduxjs/toolkit";

interface PollEditInfo {
    Poll: ModelPoll,
    EditInfoState: boolean
}

declare interface DictionaryNum<T> {
    [id: number]: T;
}

interface PollState {
    AddInfoPopup: boolean,
    EditInfoPopup: DictionaryNum<PollEditInfo>
}

const initialState: PollState = {
    AddInfoPopup: false,
    EditInfoPopup: {
        0: {Poll: {Id: 0, Title: "QuizA", Points: 3}, EditInfoState: false},
        1: {Poll: {Id: 1, Title: "QuizB", Points: 3}, EditInfoState: false}
    }
};

const PollSlice = createSlice({
    name: "Poll",
    initialState: initialState,
    reducers: {
        ShowAddInfo: state => {
            state.AddInfoPopup = true
        },
        HideAddInfo: state => {
            state.AddInfoPopup = false
        },

        ShowEditInfo: (state, action) => {
            if(state.EditInfoPopup[action.payload])
                state.EditInfoPopup[action.payload].EditInfoState = true;
        },

        HideEditInfo: (state, action) => {
            if(state.EditInfoPopup[action.payload])
                state.EditInfoPopup[action.payload].EditInfoState = false;
        }
    }
});

export const PollReducer = PollSlice.reducer;

export const PollAction = PollSlice.actions;
