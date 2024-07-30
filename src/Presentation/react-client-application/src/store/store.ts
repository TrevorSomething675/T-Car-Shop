import User from '@/models/user/User';
import {makeAutoObservable} from 'mobx';
import AuthService from '@/services/AuthService';
import axios from 'axios';
import { API_URL } from '@/http';

export default class Store{
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

    async login(userName:string, password:string)
    {
        try{
            const response = await AuthService.login(userName, password);
            console.log(response);
            localStorage.setItem('AccessToken', response.data.value.accessToken);
            localStorage.setItem('RefreshToken', response.data.value.refreshToken);
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
            console.log(response);
            localStorage.setItem('AccessToken', response.data.value.accessToken);
            localStorage.setItem('RefreshToken', response.data.value.refreshToken);
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
        } catch(error) {
            console.error(error);
        }
    }
    async checkAuth(){
        try{
            const resposnse = await axios.get(`${API_URL}/refresh`, {
                withCredentials: false
            })//Это не готово!! TO DO Нужно сделать выдачу токенов по рефреш токену
        } catch(error){
            console.error(error);
        }
    }
}