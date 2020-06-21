import {createSlice} from '@reduxjs/toolkit'

interface InitState {
    isOpen: boolean
}

const initState: InitState = {
    isOpen: false
};

const DropdownUserMenuSlice = createSlice({
    name: "dropdownusermenu",
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


export const DropdownUserMenuActions = DropdownUserMenuSlice.actions;
export const DropdownUserMenuReducer = DropdownUserMenuSlice.reducer;
