import {createAsyncThunk, createSlice} from "@reduxjs/toolkit";

import api from "../../Services/Base/Api";
import {LoginUser} from "../../Model/LoginUser";

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
    async (val: LoginUser) => {
        try {
            const response = await api({
                method: "post",
                url: "/auth/login",
                data: val
            });
            console.log(response.data);
            localStorage.setItem("user", JSON.stringify(response.data)); // TODO put in REDUX
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
            state.token = localStorage.getItem("token");
        })
    }
});


export const AuthReducer = authSlice.reducer;
export const AuthActions = authSlice.actions;