import api from "@/http";
import { AxiosResponse } from "axios";
import AuthModel from "@/models/auth/AuthModel";

class AuthService{
    static async login(userName: string, password: string): Promise<AxiosResponse<ApiResponse<AuthModel>>>{
        const formData = new FormData();

        formData.append('Name', userName);
        formData.append('Password', password);
        const response = await api.post<ApiResponse<AuthModel>>('Auth/login', formData, {headers:{
            'Content-Type': 'multipart/form-data'
        }});
        return response;
    }

    static async register(userName: string, password: string, confirmPassword: string): Promise<AxiosResponse<ApiResponse<AuthModel>>>{
        const formData = new FormData();

        formData.append('Name', userName);
        formData.append('Password', password);
        formData.append('ConfirmPassword', confirmPassword);
        const response = await api.post<ApiResponse<AuthModel>>('Auth/register', formData, {headers:{
            'Content-Type': 'multipart/form-data'
        }});
        return response;
    }

    static async logout():Promise<void>{
        return api.post('/logout');
    }
}

export default AuthService;