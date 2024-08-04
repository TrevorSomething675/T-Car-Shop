import api from '@/http/index';
import axios, { AxiosRequestConfig } from 'axios';
import qs from 'qs';

const GetCars = async (params:AxiosRequestConfig) => {
    const source = axios.CancelToken.source();
    const response = await api.get<ApiItemsResponse<Car>>('/Car', {
        cancelToken: source.token,
        params,
        paramsSerializer: params => {
            return qs.stringify(params, { arrayFormat: 'repeat' });
        }
    });
    return response;
}

export default GetCars;