import axios from 'axios';

export const API_URL = 'https://localhost:7049';

const api = axios.create({
    withCredentials: false,
    baseURL: API_URL,
});

api.interceptors.request.use((config) => {
    config.headers.Authorization = `Bearer ${localStorage.getItem('AccessToken')}`;
    return config;
});

export default api;