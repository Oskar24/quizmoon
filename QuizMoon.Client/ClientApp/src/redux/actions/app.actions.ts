import { Dispatch } from "redux";
import fetchUser from "../../hooks/UserHooks";
import * as actionTypes from "../actionTypes";

export const fetchUserData = () => async (dispatch: Dispatch) => {
    console.log(dispatch);
    try {
        const response = await fetchUser();
        console.log(response);
        if (response && response.data) {
            dispatch({ type: actionTypes.LOGIN_SUCCESS, payload: response.data });
        }
    } catch (error) {
        console.error('Error fetching data:', error);
    }
};

