import { makeAutoObservable } from "mobx";

class NotificationStore {
    notificationsData:ApiItemsResponse<UserNotification> = {} as ApiItemsResponse<UserNotification>;
    constructor(){
        makeAutoObservable(this);
    }
    setNotificationsData(data:ApiItemsResponse<UserNotification>){
        this.notificationsData = data;
    }
}

export default new NotificationStore;