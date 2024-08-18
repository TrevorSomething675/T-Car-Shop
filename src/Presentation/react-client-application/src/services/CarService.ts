import api from '@/http/index';
import qs from 'qs';
import carStore from '@/store/carStore';

class CarService {
    static GetCars = async (params:any, cancelToken:any) => {
        const response = await api.get<ApiItemsResponse<Car>>('/Car', {
            cancelToken: cancelToken,
            params,
            paramsSerializer: params => {
                return qs.stringify(params, { arrayFormat: 'repeat' });
            }
        });
        carStore.setCarsData(response?.data);
        return response;
    }
    static UpdateCar = async (params:any, cancelToken:any) => {
        const response = await api.put<Car>('/Car', {
            cancelToken: cancelToken,
            params
        })
        return response;
    }
}

export default CarService;