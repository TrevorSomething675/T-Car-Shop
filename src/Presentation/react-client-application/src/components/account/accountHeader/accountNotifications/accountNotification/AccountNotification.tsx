import Text from '@/components/text/Text';
import styles from './AccountNotification.module.css';
import { useState } from 'react';
import api from '@/http/index';
import { headers } from 'next/headers';

const AccountNotification:React.FC<{notification:UserNotification}> = ({notification}) => {
    const [IsExpanded, ChangeExpanded] = useState(false);
    const [IsChecked, ChangeChacked] = useState(notification.isChecked);

    const ClickNotificationHandler = async () => {
        ChangeExpanded(!IsExpanded);
        if(!IsChecked){
            const response = await api.post<ApiResponse<UserNotification>>('/PersonalNotification', {
                headers: {
                    'Content-Type': 'application/json'
                },
                id: notification.id,
                userId: notification.userId,
                notificationId: notification.notificationId,
                isChecked: !notification.isChecked
            }).then((response) => {
                ChangeChacked(response.data.value.isChecked);
            }).catch((error) => {
                console.error(error);
            });
        }
    };

    return <div className={IsChecked ? styles.isChackedContainer : styles.container} onClick={() => ClickNotificationHandler()}>
        <h2 className={styles.header}>{notification.notification.header}</h2>
        <div className={IsExpanded ? styles.expandedContent : styles.content}>
            <Text text={notification.notification.content} />
        </div>
    </div>
};

export default AccountNotification;