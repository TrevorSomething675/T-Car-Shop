import styles from './AccountHeader.module.css';
import store from '@/store/store';
import { observer } from 'mobx-react-lite';
import { useState } from 'react';
import UserService from '@/services/UserService';
import axios from 'axios';

const AccountHeader = observer(() => {
    const [passwordData, setPasswordData] = useState<string|null>('******');
    const changeVisibleHandler = () => {
        const cancelToken = axios.CancelToken.source();
        const params = {
            userId: store?.user?.id
        };
        var response = UserService.GetUserById(params, cancelToken.token).then((response) => {
            setPasswordData(response?.data?.value?.password);
        });
    }

    return <div className={styles.container}>
        <h2 className={styles.h2}>
            Личный кабинет
        </h2>
        <div className={styles.dataContainer}>
            <div className={styles.dataItem}>
                Логин:
                <span className={styles.loginField}>
                    {store?.user?.name}
                </span> 
            </div>
            <div className={styles.passwordDataItem} onClick={changeVisibleHandler}>
                Пароль:
                <span className={styles.passwordField}>
                    {passwordData}
                </span>
            </div>
        </div>
    </div>
});

export default AccountHeader;