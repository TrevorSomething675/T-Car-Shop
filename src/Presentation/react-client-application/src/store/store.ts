import User from '@/models/user/User';
import { makeAutoObservable } from 'mobx';
import AuthService from '@/services/AuthService';

class Store{
    user = {} as User;
    isAuth = false;
    constructor(){
        makeAutoObservable(this);
    }
    setAuth(isAuth:boolean){
        this.isAuth = isAuth;
    }
    setUser(user:User){
        this.user = user;
    }
    async checkAuth(){
        const isAuth = localStorage.getItem('isAuth');
        if(isAuth == 'true'){
            this.setAuth(true);
            this.setUser({
                name: localStorage.getItem('userName'),
                id: localStorage.getItem('id'),
            } as User)
        } else {
            this.setAuth(false);
        }
    }
    async login(userName:string, password:string)
    {
        try{
            const response = await AuthService.login(userName, password);
            localStorage.setItem('AccessToken', response.data.value.accessToken);
            localStorage.setItem('RefreshToken', response.data.value.refreshToken);
            localStorage.setItem('userName', response.data.value.user.name);
            localStorage.setItem('id', response.data.value.user.id)
            localStorage.setItem('isAuth', 'true');
            this.setAuth(true);
            this.setUser(response.data.value.user);
        }
        catch(error){
            console.error(error);
        }
    }
    async register(userName:string, password:string, confirmPassword:string){
        try{
            const response = await AuthService.register(userName, password, confirmPassword);
            localStorage.setItem('AccessToken', response.data.value.accessToken);
            localStorage.setItem('RefreshToken', response.data.value.refreshToken);
            localStorage.setItem('userName', response.data.value.user.name);
            localStorage.setItem('id', response.data.value.user.id)
            localStorage.setItem('isAuth', 'true');
            this.setAuth(true);
            this.setUser(response.data.value.user);
        }
        catch(error){
            console.error(error);
        }
    }
    async logout(){
        try{
            this.setAuth(false);
            this.setUser({} as User);
            localStorage.removeItem('AccessToken');
            localStorage.removeItem('RefreshToken');
            localStorage.removeItem('userName');
            localStorage.removeItem('id');
            localStorage.removeItem('isAuth');
        } catch(error) {
            console.error(error);
        }
    }
}

export default new Store();