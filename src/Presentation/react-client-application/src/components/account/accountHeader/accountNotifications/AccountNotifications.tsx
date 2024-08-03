import AccountNotification from './accountNotification/AccountNotification';
import styles from './AccountNotifications.module.css';

const AccountNotifications:React.FC<{notifications:UserNotification[]}> = ({notifications}) => {
    notifications.sort(function(a){
        if(a.isChecked == true){
            return 1;
        }
        if(a.isChecked == false){
            return -1;
        }
        return 0;
    });
    return <div className={styles.container}>
        {notifications.map((notification) => 
            <AccountNotification key={notification.id} notification={notification} />
        )}
    </div>
}

export default AccountNotifications;