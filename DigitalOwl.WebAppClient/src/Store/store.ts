import {combineReducers, configureStore, getDefaultMiddleware} from '@reduxjs/toolkit'
import {SidebarReducer} from "../Component/Sidebar/SidebarSlice";

const reducers = combineReducers({
    SidebarReducer
});

type ReducerType = ReturnType<typeof reducers>;

export const store = configureStore({
    reducer: reducers,
    middleware: [
        ...getDefaultMiddleware<ReducerType>(),
    ] as const
});


export type StateType = ReturnType<typeof store.getState>
export type DispatchType = typeof store.dispatch