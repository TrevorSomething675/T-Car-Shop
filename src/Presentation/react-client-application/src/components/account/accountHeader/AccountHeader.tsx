import styles from './AccountHeader.module.css';
import AccountNotification from './accountNotification/AccountNotification';
import AccountUser from './accountUser/AccountUser';

const AccountHeader = () => {
    return <div className={styles.container}>
        <AccountUser />
        <AccountNotification />
    </div>
}

export default AccountHeader;