interface UserNotification{
    id: string;
    userId: string;
    notificationId: string;
    isChecked: boolean;
    createdDate: Date;
    notification: Notification;
}