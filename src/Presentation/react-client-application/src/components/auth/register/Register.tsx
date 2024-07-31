import { SubmitHandler, useForm } from "react-hook-form";
import styles from './Register.module.css';
import { useContext, useState } from "react";
import { useRouter } from 'next/navigation'; 
import store from '@/store/store';

interface RegisterForm {
    name: string;
    password: string;
    confirmPassword: string;
}

const Register: React.FC<{ changeAuthForm: any }> = ({ changeAuthForm }) => {
    const handleChangeAuthForm = () => {
        changeAuthForm(true);
    }
    const router = useRouter();
    const [errors, setErrors] = useState<string>('');
    const { register, handleSubmit } = useForm<RegisterForm>();

    const submit: SubmitHandler<RegisterForm> = async (data) => {
        setErrors('');
        await store.register(data.name, data.password, data.confirmPassword);
        router.push('/');
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
    return (
        <form onSubmit={handleSubmit(submit)} className={styles.container}>
            <div className={styles.header}>
                Регистрация
            </div>
            <div className={styles.body}>
                <label
                    className={styles.label}
                    htmlFor='userName'>Логин:
                </label>
                <input
                    id='userName'
                    type='text'
                    className={styles.input}
                    {...register('name', { required: true, validate: validator})}
                />
                <label
                    className={styles.label}
                    htmlFor='password'>Пароль:
                </label>
                <input
                    id='password'
                    type='password'
                    className={styles.input}
                    {...register('password', { required: true, validate: validator })}
                />
                <label
                    className={styles.label}
                    htmlFor='confirmPassword'>Подтверждение пароля:
                </label>
                <input
                    id='confirmPassword'
                    type='password'
                    className={styles.input}
                    {...register('confirmPassword', { required: true, validate: validator })}
                />
                {errors && <div className={styles.errors}>
                    Введены неверные данные
                </div>}
                <div>
                    <button className={styles.button} type='button' onClick={handleChangeAuthForm}>
                        Уже зарегистрированы?
                    </button>
                </div>
            </div>
            <div className={styles.footer}>
                <button type='submit' className={styles.submitButton}>
                    Зарегистрироваться
                </button>
            </div>
        </form>
    )
}

export default Register;