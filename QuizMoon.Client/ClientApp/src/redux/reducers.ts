import { PayloadAction } from "@reduxjs/toolkit";
import { combineReducers } from "redux";
import * as actionTypes from "./actionTypes";

interface User {
    email: string;
}

interface AuthState {
    isLoggedIn: boolean;
    user: User | null;
}

const initialState: AuthState = {
    isLoggedIn: false,
    user: null,
};

const authReducer = (state = initialState, action: PayloadAction<User>) => {
    switch (action.type) {
        case actionTypes.LOGIN_SUCCESS:
            return {
                ...state,
                isLoggedIn: true,
                user: action.payload,
            };
        case actionTypes.LOGOUT_SUCCESS:
            return {
                ...state,
                isLoggedIn: false,
                user: null,
            };
        default:
            return state;
    }
};

const rootReducer = combineReducers({
    auth: authReducer,
})

export default rootReducer;