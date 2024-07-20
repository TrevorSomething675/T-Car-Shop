'use client'

import Header from '@/app/header/Header';
import Footer from '@/app/footer/Footer';
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Cars from '@/components/cars/Cars';

const CarsPage = () => {
    const [cars, setCars] = useState<Car[]>([]);

    useEffect(() => {
        const source = axios.CancelToken.source();
        const fetchData = async () => {
            try {
                const response = await axios.get<ApiResponse>('https://localhost:7049/Car', {
                    cancelToken: source.token,
                    params:{
                    }
                });
                setCars(response.data.value.items);
            } catch (error) {
                console.error(error);
            }
        };

        fetchData();

        return () => {
            source.cancel('Operation canceled by the user.');
        };
    }, []);

    return (
        <div className='page-container'>
            <Header />
            <div className='page-body'>
                <Cars cars={cars} />
            </div>
            <Footer />
        </div>
    );
};

export default CarsPage;