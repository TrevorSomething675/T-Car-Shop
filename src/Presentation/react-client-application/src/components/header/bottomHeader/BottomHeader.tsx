import Link from 'next/link';
import styles from './BottomHeader.module.css';
import SvgNotificationIcon from '@/components/svgs/notificationIcon/NotificationIcon';
import SvgFavoriteIcon from '@/components/svgs/favoriteIcon/FavoriteIcon';
import SvgLoginIcon from '@/components/svgs/loginIcon/LoginIcon';
import store from '@/store/store';
import { observer } from 'mobx-react-lite';
import { useEffect, useState } from 'react';

const BottomHeader = observer(() => {
    const [loading, setLoading] = useState(true);
    useEffect(() =>{
        const checkAuth = async () =>{
            await store.checkAuth();
            setLoading(false)
        };
        checkAuth();
    }, []);

    return <div className = {styles.bottomHeader}>
        <div className={styles.leftNavBar}>
            <ul className={styles.ul}>
                <li className={styles.li}>
                    <Link href='/cars'>
                        <button className={styles.button}>Машины</button>
                    </Link>
                </li>
                <li className={styles.li}>
                    <Link href='/manufacturers'>
                        <button className={styles.button}>Производители</button>
                    </Link>
                </li>
                <li className={styles.li}>
                    <button className={styles.button}>Хит продаж</button>
                </li>
                <li className={styles.li}>
                    <button className={styles.button}>Скидки</button>
                </li>
            </ul>
        </div> 

        <div className={styles.rightNavBar}>
            <ul className={styles.ul}>
                {store.isAuth && 
                <>
                    <li className={styles.li}>
                        <button className={styles.button}>
                            <SvgNotificationIcon />
                            Уведомления
                        </button>
                    </li>
                    <li className={styles.li}>
                        <button className={styles.button}>
                            <SvgFavoriteIcon />
                            Избранное
                        </button>
                    </li>
                </>}
                {!loading &&
                <>
                    {store.isAuth ? 
                    <li className={styles.li}>
                        <Link href='/account'>
                            <button className={styles.button}>
                                <SvgLoginIcon />
                                {store.user.name}
                            </button>
                        </Link>
                    </li> : <li className={styles.li}>
                        <Link href='/auth'>
                            <button className={styles.button}>
                                <SvgLoginIcon />
                                Вход/Регистрация
                            </button>
                        </Link>
                    </li> }
                </>}
            </ul>
        </div>
    </div>
});  

export default BottomHeader;