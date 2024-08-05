'use client'

import Link from 'next/link';
import styles from './BottomHeader.module.css';
import SvgNotificationIcon from '@/components/svgs/notificationIcon/NotificationIcon';
import SvgFavoriteIcon from '@/components/svgs/favoriteIcon/FavoriteIcon';
import SvgLoginIcon from '@/components/svgs/loginIcon/LoginIcon';
import store from '@/store/store';
import { observer } from 'mobx-react-lite';
import { useEffect, useState } from 'react';
import CarService from '@/services/CarService';
import axios from 'axios';

const BottomHeader = observer(() => {
    const fetchCarsWithHitOffer = async () => {
        const cancelToken = axios.CancelToken.source();
        const params = {
            sampleType: 1,
            includes: ["Offers", "Images"]
        };
        const result = await CarService.GetCars(params, cancelToken.token);
    }

    const fetchCarsWithSaleOffer = async () => {
        const cancelToken = axios.CancelToken.source();
        const params = {
            sampleType: 2,
            includes: ["Offers", "Images"]
        };
        const result = await CarService.GetCars(params, cancelToken.token);
    }

    const fetchCars = async () => {
        const cancelToken = axios.CancelToken.source();
        const params = {
            includes: ["Offers", "Images"]
        };
        const result = await CarService.GetCars(params, cancelToken.token);
    }

    const fetchFavoriteCars = async () => {
        const cancelToken = axios.CancelToken.source();
        const params = {
            userId: store?.user?.id,
            sampleType: 3,
            includes: ["Offers", "Images", "UserCar"]
        }
        const result = await CarService.GetCars(params, cancelToken.token);
    }

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
                        <button className={styles.button} onClick={fetchCars}>Машины</button>
                    </Link>
                </li>
                <li className={styles.li}>
                    <Link href='/manufacturers'>
                        <button className={styles.button}>Производители</button>
                    </Link>
                </li>
                <li className={styles.li}>
                    <Link href='/cars'>
                        <button className={styles.button} onClick={fetchCarsWithHitOffer}>Хит продаж</button>
                    </Link>
                </li>
                <li className={styles.li}>
                    <Link href='/cars'>
                        <button className={styles.button} onClick={fetchCarsWithSaleOffer}>Скидки</button>
                    </Link>
                </li>
            </ul>
        </div>

        <div className={styles.rightNavBar}>
            <ul className={styles.ul}>
                {store.isAuth && 
                <>
                    <li className={styles.li}>
                        <Link href='/account'>
                            <button className={styles.button}>
                                <SvgNotificationIcon />
                                Уведомления
                            </button>
                        </Link>
                    </li>
                    <li className={styles.li}>
                        <Link href="/cars">
                            <button className={styles.button} onClick={fetchFavoriteCars}>
                                <SvgFavoriteIcon />
                                Избранное
                            </button>
                        </Link>
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