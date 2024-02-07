import axios, { AxiosResponse } from "axios";
import Config from "../config";

interface User {
}

const fetchUser = async (): Promise<AxiosResponse<User>> => {
    try {
        return await axios.get<User>(`${Config.baseApiUrl}/account/getuser?slide=false`);
    } catch (error) {
        return Promise.reject(error);
    }
}

export default fetchUser;
