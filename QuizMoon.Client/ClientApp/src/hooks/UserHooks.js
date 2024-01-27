import axios from "axios";
import Config from "../config";

const fetchUser = async () => {
    return await axios.get(`${Config.baseApiUrl}/account/getuser?slide=false`)
        .then((response) => { return response })
        .catch((error) => { console.log("error:", error); });
}

export default fetchUser;
