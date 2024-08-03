import styles from './AccountHeader.module.css';
import AccountNotifications from './accountNotifications/AccountNotifications';
import AccountUser from './accountUser/AccountUser';

const AccountHeader:React.FC<{notifications:UserNotification[]}> = ({notifications}) => {
    return <div className={styles.container}>
        <AccountUser />
        <AccountNotifications notifications={notifications}/>
    </div>
}

export default AccountHeader;