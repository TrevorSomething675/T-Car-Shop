import styles from './AccountBotton.module.css';
import store from '@/store/store';
import { useRouter } from 'next/navigation';
import CarService from '@/services/CarService';
import axios from 'axios';

const AccountBotton = () => {
    const router = useRouter();

    const logout = async () =>{
        store.logout();
        const source = axios.CancelToken.source();
        const params = {
            includes: ['Images', 'Offers'],
            pageNumber: 1,
        };
        await CarService.GetCars(params, source.token);
        router.push('/');
    };

    return <div className={styles.container}>
        <div>
            <button className={styles.changeAccountDataButton}>Изменить пароль</button>
            <button className={styles.changeAccountDataButton}>Изменить логин</button>
        </div>
        <button className={styles.exitButton} onClick={logout}>
            Выйти
        </button>
    </div>
}

export default AccountBotton;