import User from "@/models/user/User"
import api from "@/http"

class UserService{
    static GetUserById = async (params:any, cancelToken:any) => {
        const response = await api.get<ApiResponse<User>>('/User/GetById', {
            cancelToken:cancelToken,
            params,
        })
        return response;
    }
}

export default UserService;