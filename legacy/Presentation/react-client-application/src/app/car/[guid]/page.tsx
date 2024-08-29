'use client'

import Header from '@/components/header/Header';
import Footer from '@/components/footer/Footer';
import { usePathname } from 'next/navigation';
import { useEffect, useState } from 'react';
import MainCarCard from '@/components/cars/mainCarCard/MainCarCard';
import api from '@/http';
import qs from 'qs';
import { toJS } from 'mobx';
import store from '@/store/store';

const CarPage = () => {
    const [car, setCar] = useState<Car | null>(null);
    const pathname = usePathname();

    useEffect(() => {
        const includes:string[] = ["Images", "UserCar"];
        const id = pathname.split('/').pop();
        const fetchData = async () => {
            const response = await api.get<ApiResponse<Car>>(`https://localhost:7049/Car/${id}`, {
                params:{
                    Id: id,
                    Includes: includes,
                    ImagesFillingType: 0,
                    UserId: toJS(store.user.id)
                },
                paramsSerializer: params => {
                    return qs.stringify(params, { arrayFormat: 'repeat' });
                }
            })
            setCar(response?.data?.value);
        }
        
        fetchData();
    }, [])

    return <div className='page-container'>
        <Header />
        <div className='page-body'>
        {
            car != null &&
            <MainCarCard car = {car}/>
        }
        </div>
        <Footer />
    </div>
}

export default CarPage;