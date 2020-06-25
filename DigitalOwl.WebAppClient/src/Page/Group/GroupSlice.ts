import {createAsyncThunk, createSlice, PayloadAction} from "@reduxjs/toolkit";
import {ModelGroup} from "../../Model/ModelGroup";
import {GroupGetAllService, GroupGetByIdService} from "../../Services/GroupService";


export interface groupState {
    group: ModelGroup[],
    groupExist: boolean
}

const initState: groupState = {
    group: [
        {id: 1, name: "string"},
        {id: 2, name: "test"},
    ],
    groupExist: false
}

export const GroupGetAllThunk = createAsyncThunk<ModelGroup[], void>(
    "group/getAll",
    async () => {
        try {
            const respose = await GroupGetAllService();
            return (respose.data.Json()) as ModelGroup[];
            // console.log(respose);
        } catch (e) {
            console.log(e);
            return [];
        }

    }
);

export const GroupGetByIdThunk = createAsyncThunk<ModelGroup | null, number>(
    "group/getById",
    async (id: number) => {
        try {
            const respose = await GroupGetByIdService(id);
            // console.log(respose);
            return (respose.data.Json()) as ModelGroup;
        } catch (e) {
            console.log(e);
            return null;
        }

    }
);

const GroupSlice = createSlice({
    name: "group",
    initialState: initState,
    reducers: {},
    extraReducers: builder => {
        builder.addCase(GroupGetAllThunk.fulfilled,
            (state, actions: PayloadAction<ModelGroup[]>) => {
                console.log(actions) // TODO delete me
                // state.group = actions.payload
            }
        )
        builder.addCase(GroupGetByIdThunk.fulfilled,
            (state, actions: PayloadAction<ModelGroup | null>) => {
                state.groupExist = true
                state.group = actions.payload == null ? [] : [actions.payload]
            }
        )
        builder.addCase(GroupGetByIdThunk.rejected,
            (state) => {
                state.groupExist = false
            }
        )

    }
});


export const GroupReducer = GroupSlice.reducer;
export const GroupActions = GroupSlice.actions;