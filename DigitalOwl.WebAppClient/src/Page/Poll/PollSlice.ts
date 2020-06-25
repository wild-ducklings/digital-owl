import {ModelCreatePoll, ModelPoll} from "../../Model/ModelPoll";
import {createAsyncThunk, createSlice} from "@reduxjs/toolkit";
import {PollCreateService, PollGetAllService, PollGetByIdService} from "../../Services/PollService";

export interface PollEditInfo {
    Poll: ModelPoll,
    EditInfoState: boolean
}

interface PollState {
    AddInfoPopup: boolean,
    EditInfoPopup: PollEditInfo[],
    CreatePoll: boolean,
    CreatedPoll: boolean
}

const initialState: PollState = {
    AddInfoPopup: false,
    EditInfoPopup: [],
    CreatePoll: false,
    CreatedPoll: false

};


export const GetAllPollThunk = createAsyncThunk<ModelPoll[], void>(
    "poll/getall",
    async () => {
        try {
            const response = await PollGetAllService();
            return (response.data) as ModelPoll[];
        } catch (e) {
            console.log(e);
            return [];
        }
    }
)

export const GetPollThunk = createAsyncThunk<ModelCreatePoll | null, number>(
    "poll/getbyid",
    async (id: number) => {
        try {
            const response = await PollGetByIdService(id);
            return (response.data) as ModelCreatePoll;
        } catch (e) {
            console.log(e);
            return null;
        }
    }
)

export const CreatePollThunk = createAsyncThunk(
    "create_quiz",
    async (val: ModelCreatePoll) => {
        const response = await PollCreateService(val);
        console.log(response.data);
    }
)
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
            state.EditInfoPopup.map((x) => {
                if (x.Poll.id == action.payload)
                    x.EditInfoState = true;
            })
        },

        HideEditInfo: (state, action) => {
            state.EditInfoPopup.map((x) => {
                if (x.Poll.id == action.payload)
                    x.EditInfoState = false;
            })
        },

        CreatedPollRedirect: state => {
            state.CreatedPoll = true;
        },

        NegateCreatedPoll: state => {
            state.CreatedPoll = false;
        },

        CreatePollRedirect: state => {
            state.CreatePoll = true;
        },

        NegateCreatePoll: state => {
            state.CreatePoll = false;
        }
    },

    extraReducers: builder => {
        builder.addCase(CreatePollThunk.fulfilled, state => {
            state.CreatedPoll = true;
        })
        builder.addCase(GetAllPollThunk.fulfilled, (state, action) => {
            console.log(action.payload)
            state.EditInfoPopup = [];
            action.payload.forEach((p) => {
                console.log(p);
                state.EditInfoPopup.push({Poll: p, EditInfoState: false});
            })
        })
    }
});

export const PollReducer = PollSlice.reducer;
export const PollAction = PollSlice.actions;
