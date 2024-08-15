import styles from './Notifications.module.css';
import Notification from './Notification';

const Notifications:React.FC<{notifications:UserNotification[]}> = ({notifications}) => {
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
            <Notification key={notification.id} notification={notification} />
        )}
    </div>
}

export default Notifications;