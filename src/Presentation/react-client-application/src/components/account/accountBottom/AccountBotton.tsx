import styles from './AccountBotton.module.css';
import store from '@/store/store';
import { useRouter } from 'next/navigation';

const AccountBotton = () => {
    const router = useRouter();

    const logout = () =>{
        store.logout();
        router.push('/');
    };

    return <div className={styles.container}>
        <div>
            goisdfj
        </div>
        <button className={styles.exitButton} onClick={logout}>
            Выйти
        </button>
    </div>
}

export default AccountBotton;