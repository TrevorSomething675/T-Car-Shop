'use client'

import styles from './Account.module.css';
import AccountBotton from './accountBottom/AccountBotton';
import AccountHeader from './accountHeader/AccountHeader';

const Account = () => {
    return <div className={styles.container}>
        <AccountHeader />
        <AccountBotton />
    </div>
}

export default Account;