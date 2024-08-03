'use client'

import { useEffect, useState } from 'react';
import styles from './Account.module.css';
import AccountBotton from './accountBottom/AccountBotton';
import AccountHeader from './accountHeader/AccountHeader';
import api from '@/http/index';

const Account = () => {
    const [notifications, setNotifications] = useState<UserNotification[]>([]);
    useEffect(() => {
        const userId = localStorage.getItem('id');
        const response = api.get<ApiItemsResponse<UserNotification>>('/PersonalNotification', 
        {
            params: {
                userId: userId,
                includes: "Notification",
            }
        }).then((response) => {
            console.log(response.data.value.items);
            setNotifications(response.data.value.items);
        })
    }, []);
    return <div className={styles.container}>
        <AccountHeader notifications={notifications}/>
        <AccountBotton />
    </div>
}

export default Account;