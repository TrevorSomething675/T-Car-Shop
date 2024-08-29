'use client'

import Login from '@/components/auth/login/Login';
import Register from '@/components/auth/register/Register';

import styles from './Auth.module.css';
import { useState } from "react";

const Auth = () => {
    const changeAuthForm = (stateAuthForm:boolean) =>{
        setIsLogin(stateAuthForm);
    }
    const [isLogin, setIsLogin] = useState(true);
    return <div className={styles.container}>
        <div className={styles.form}>
            {isLogin ? <Login changeAuthForm={changeAuthForm} /> :
             <Register changeAuthForm={changeAuthForm}/> }
        </div>
    </div>
};

export default Auth;