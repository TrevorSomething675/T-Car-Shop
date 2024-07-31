'use client'

import Header from '@/components/header/Header';
import Footer from '@/components/footer/Footer';
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Cars from '@/components/cars/Cars';
import Pagging from '@/components/pagging/Paggind';
import CarsHeader from '@/components/cars/carsHeader/CarsHeader';
import api from '@/http/index';

const CarsPage = () => {
    const [cars, setCars] = useState<Car[]>([]);
    const [pageCount, setPageCount] = useState<number>(1);

    const fetchData = async (pageNumber: number, cancelToken: any) => {
        try {
            const response = await api.get<ApiItemsResponse<Car>>('/Car', {
                cancelToken: cancelToken.token,
                params: {
                    pageNumber: pageNumber,
                    Includes: ['Images'].join(',')
                }
            });
            setCars(response.data.value.items);
            setPageCount(response.data.value.pageCount);
        } catch (error) {
            if (axios.isCancel(error)) {
                console.log();
            } else {
                console.error();
            }
        }
    };

    const handlePageNumberChange = (pageNumber: number) => {
        const source = axios.CancelToken.source();
        fetchData(pageNumber, source);
    };

    useEffect(() => {
        const source = axios.CancelToken.source();
        fetchData(1, source); 

        return () => {
            source.cancel();
        };
    }, []);

    return <div className='page-container'>
        <Header />
        <div className='page-body'>
            <CarsHeader />
            <Cars cars={cars} />
            <Pagging pageCount={pageCount} onPageNumberChange={handlePageNumberChange} />
        </div>
        <Footer />
    </div>
};

export default CarsPage;