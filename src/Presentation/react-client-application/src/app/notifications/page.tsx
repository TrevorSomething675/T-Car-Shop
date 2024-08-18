'use client'

import Header from '@/components/header/Header';
import Footer from '@/components/footer/Footer';
import Notifications from '@/components/notifications/Notifications';
import { useEffect, useState } from 'react';
import NotificationsHeader from '@/components/notifications/notificationsHeader/NotificationsHeader';
import Pagging from '@/components/pagging/Paggind';
import PersonalNotificationService from '@/services/PersonalNotificationService';
import store from '@/store/store';
import { toJS } from 'mobx';
import axios from 'axios';
import notificationStore from '@/store/notificationStore';
import { observer } from 'mobx-react-lite';

const AccountPage = observer(() => {
    const fetchData = async (params:any, cancelToken:any) => {
        await PersonalNotificationService.GetPersonalNotifications(params, cancelToken);
    }
    const handlePageNumberChange = (pageNumber:number) => {
        const source = axios.CancelToken.source();
        const userId = toJS(store.user.id);
        const params = {
            userId: userId,
            pageNumber: pageNumber,
            includes: "Notification"
        }
        fetchData(params, source.token);
    };

    useEffect(() => {
        const source = axios.CancelToken.source(); 
        const userId = toJS(store.user.id);
        const params = {
            userId: userId,
            pageNumber: 1,
            includes: "Notification"
        }
        fetchData(params, source.token);
    }, []);

    return <div className='page-container'>
        <Header isSmallHeader={true}/>
        <div className='page-body'>
            <NotificationsHeader />
            <Notifications notifications={toJS(notificationStore?.notificationsData?.value?.items)}/>
            <Pagging pageCount={toJS(notificationStore?.notificationsData?.value?.pageCount)} onPageNumberChange={handlePageNumberChange}/>
        </div>        
        <Footer />
    </div>
});

export default AccountPage;