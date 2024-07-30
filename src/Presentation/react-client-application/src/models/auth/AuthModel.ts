import User from '@/models/user/User';

interface AuthModel{
    user:User;
    accessToken:string;
    refreshToken:string;
}

export default AuthModel;