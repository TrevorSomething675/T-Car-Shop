'use client'

import Header from '@/components/header/Header';
import Footer from '@/components/footer/Footer';
import Notifications from '@/components/notifications/Notifications';
import { useEffect, useState } from 'react';
import api from '@/http';
import NotificationsHeader from '@/components/notifications/notificationsHeader/NotificationsHeader';

const AccountPage = () => {
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
            setNotifications(response.data.value.items);
        })
    }, []);

    return <div className='page-container'>
        <Header isSmallHeader={true}/>
        <div className='page-body'>
            <NotificationsHeader />
            <Notifications notifications={notifications}/>
        </div>        
        <Footer />
    </div>
};

export default AccountPage;