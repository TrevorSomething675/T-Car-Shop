import Link from 'next/link';
import styles from './BottomHeader.module.css';
import SvgNotificationIcon from '@/components/svgs/notificationIcon/NotificationIcon';
import SvgFavoriteIcon from '@/components/svgs/favoriteIcon/FavoriteIcon';
import SvgLoginIcon from '@/components/svgs/loginIcon/LoginIcon';
import { useContext } from "react";
import {Context} from '@/app/layout';

const BottomHeader = () => {
    const {store} = useContext(Context)

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
                <li>
                    {store.isAuth ? <button className={styles.button}>TRUE</button>
                     : <button className={styles.button}>FALSE</button>}
                </li>
            </ul>
        </div> 

        <div className={styles.rightNavBar}>
            <ul className={styles.ul}>
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
                <li className={styles.li}>
                    <Link href='/auth'>
                        <button className={styles.button}>
                            <SvgLoginIcon />
                            Вход/Регистрация
                        </button>
                    </Link>
                </li>
            </ul>
        </div>
    </div>
}   

export default BottomHeader;