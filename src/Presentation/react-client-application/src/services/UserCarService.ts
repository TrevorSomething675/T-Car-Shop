import api from '@/http/index';
import qs from 'qs';

class UserCarService {
    static RemoveUserCar = async (userCar: UserCar, cancelToken: any) => {
        const response = await api.delete<ApiResponse<UserCar>>('/PersonalCar', {
            cancelToken: cancelToken,
            params: {
                id: userCar.id,
                userId: userCar.userId,
                carId: userCar.carId
            },
            paramsSerializer: params => {
                return qs.stringify(params, { arrayFormat: 'repeat' });
            }
        });
        return response;
    }
    static CreateUserCar = async (userCar: UserCar, cancelToken: any) => {
        const response = await api.post<ApiResponse<UserCar>>('/PersonalCar', {
            id: userCar.id,
            userId: userCar.userId,
            carId: userCar.carId
        },
        {
            cancelToken: cancelToken
        });
        return response;
    }
}

export default UserCarService;