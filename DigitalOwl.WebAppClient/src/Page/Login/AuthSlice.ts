import {createAsyncThunk, createSlice} from "@reduxjs/toolkit";

import {FormValues} from "./Login";
import api from "../../Api/Api";

export interface authState {
    login: boolean,
    token: string | null
}

const initState: authState = {
    login: localStorage.getItem("token") != null,
    token: localStorage.getItem("token")
}
export const fetchRegisterUser = createAsyncThunk(
    "register",
    async (val: FormValues) => {
        try {
            const response = await api({
                method: "post",
                url: "http://localhost:5000/api/auth/login",
                data: val
            });
            console.log(response.data);
            let resJson = JSON.stringify(response.data);
            localStorage.setItem("user", resJson);
            localStorage.setItem("token", response.data.token);
        } catch (e) {
            console.log(e);
            throw e; // temporary
        }
    }
);
const authSlice = createSlice({
    name: "auth",
    initialState: initState,
    reducers: {
        login: (state, action) => {
            state.token = action.payload;
        },
        logout: state => {
            state.login = false
            state.token = null;
            localStorage.removeItem("token");
            localStorage.removeItem("user");
        },
    },
    extraReducers: builder => {
        builder.addCase(fetchRegisterUser.fulfilled, state => {
            state.login = true;

        })
    }
});


export const AuthReducer = authSlice.reducer;
export const AuthActions = authSlice.actions;