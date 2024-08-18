'use client'

import styles from './Account.module.css';
import AccountHeader from './accountHeader/AccountHeader';
import AccountBody from './accountBody/AccountBody';
import AccountBotton from './accountBottom/AccountBotton';

const Account = () => {
    return <div className={styles.container}>
        <AccountHeader />
        <AccountBody />
        <AccountBotton />
    </div>
}

export default Account;