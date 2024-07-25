'use client'

import Header from '@/components/header/Header';
import Footer from '@/components/footer/Footer';
import { usePathname } from 'next/navigation';
import { useEffect, useState } from 'react';
import axios from 'axios';
import MainCarCard from '@/components/cars/mainCarCard/MainCarCard';

const CarPage = () => {
    const [car, setCar] = useState<Car | null>(null);
    const pathname = usePathname();

    useEffect(() => {
        const includes:string[] = ["Images"];
        const id = pathname.split('/').pop();
        const fetchData = async () => {
            const response = await axios.get<ApiResponse<Car>>(`https://localhost:7049/Car/${id}`, {
                params:{
                    Id: id,
                    Includes: includes.join(',')
                }
            })
            setCar(response.data.value);
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