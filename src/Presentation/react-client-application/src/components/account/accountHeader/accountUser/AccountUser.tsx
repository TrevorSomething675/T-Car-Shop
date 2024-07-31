'use client'

import styles from './AccountUser.module.css'
import store from '@/store/store';
import { observer } from 'mobx-react-lite';

const AccountUser = observer(() => {
    return <div className={styles.container}>
        <h2 className={styles.h2}>
            {store?.user?.name}
        </h2>
    </div>
});

export default AccountUser;