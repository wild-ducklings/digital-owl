import {createAsyncThunk, createSlice, PayloadAction} from "@reduxjs/toolkit";
import {ModelGroup} from "../../Model/ModelGroup";
import {GroupGetAllService} from "../../Services/GroupService";


export interface groupState {
    group: ModelGroup[]
}

const initState: groupState = {
    group: []
}

export const GroupGetAllThunk = createAsyncThunk<ModelGroup[]>(
    "group/getAll",
    async () => {
        try {
            const respose = await GroupGetAllService();
            // console.log(respose);
            return respose.data;
        } catch (e) {
            console.log(e);
        }

    }
);

const GroupSlice = createSlice({
    name: "group",
    initialState: initState,
    reducers: {},
    extraReducers: builder => {
        builder.addCase(GroupGetAllThunk.fulfilled, (state,
                                                     actions: PayloadAction<ModelGroup[]>) => {
                console.log(actions)
                state.group = actions.payload
                console.log("done")
            }
        )
        builder.addCase(GroupGetAllThunk.pending, (state) => {
                console.log("pending")
            }
        )
    }
});


export const GroupReducer = GroupSlice.reducer;
export const GroupActions = GroupSlice.actions;