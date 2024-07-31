import { SubmitErrorHandler, SubmitHandler, useForm } from "react-hook-form";
import styles from './Login.module.css';
import { useState } from "react";
import { useRouter } from "next/navigation";
import { observer } from "mobx-react-lite";
import store from '@/store/store';

interface LoginForm{
    name:string;
    password:string;
}

const Login:React.FC<{changeAuthForm:any}> = observer(({changeAuthForm}) => {
    const router = useRouter();
    const handleChangeAuthForm = () =>{
        changeAuthForm(false);
    }
    const [errors, setErrors] = useState<string>('');
    const {register, handleSubmit} = useForm<LoginForm>();

    const submit:SubmitHandler<LoginForm> = async (data) =>{
        setErrors('');
        await store.login(data.name, data.password);
        router.push('/');
    }
    const error:SubmitErrorHandler<LoginForm> = (data) =>{
        console.log(data);
    }
    const validator = (data:string) => {
        if(data != null && data.length > 8){
            setErrors('');
            return true;
        } else {
            setErrors('Неверно введены данные')
            return false;
        }
    }
    return <form onSubmit={handleSubmit(submit, error)} className={styles.container}>
        <div className={styles.header}>
            Логин
        </div>
        <div className={styles.body}>
            <label
                className={styles.label} 
                htmlFor='userName'>Логин / E-mail: </label>
            <input id='userName' type='text' 
                {...register('name', {required: true, validate: validator})}
                className={styles.input} />
            <label
                className={styles.label} 
                htmlFor='password'>Пароль:</label>
            <input id='password' type='password' 
                {...register('password', {validate: validator})}
                className={styles.input} />
            {errors && <div className={styles.errors}>
                Введены неверные данные
            </div>}
            <div>
                <button className={styles.button} onClick={handleChangeAuthForm} type='button'>Ещё не зарегистрированы?</button>
            </div>
        </div>
        <div className={styles.footer}>
            <button type='submit' className={styles.submitButton}>
                Войти
            </button>
        </div>
    </form>
});

export default Login;