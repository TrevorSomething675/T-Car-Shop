import api from '@/http/index';
import qs from 'qs';
import notificationStore from '@/store/notificationStore';

class PersonalNotificationService {
    static GetPersonalNotifications = async (params:any, cancelToken:any) => {
        const response = await api.get<ApiItemsResponse<UserNotification>>('/PersonalNotification', {
            cancelToken: cancelToken,
            params: params,
            paramsSerializer: params => {
                return qs.stringify(params, {arrayFormat: 'repeat'});
            }
        });
        notificationStore.setNotificationsData(response?.data);
        return response;
    }
}

export default PersonalNotificationService;