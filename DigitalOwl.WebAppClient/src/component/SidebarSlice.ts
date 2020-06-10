import {createSlice} from '@reduxjs/toolkit'

interface InitState {
    isOpen: boolean
}

const initState: InitState = {
    isOpen: false
};

const SidebarSlice = createSlice({
    name: "sidebar",
    initialState: initState,
    reducers: {
        openSidebar: (state) => {
            state.isOpen = true
        },
        closeSidebar: (state) => {
            state.isOpen = false
        },
    }
});


export const SidebarActions = SidebarSlice.actions;
export const SidebarReducer = SidebarSlice.reducer;