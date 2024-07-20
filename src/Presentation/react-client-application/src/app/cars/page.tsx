'use client'

import Header from '@/components/header/Header';
import Footer from '@/components/footer/Footer';
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Cars from '@/components/cars/Cars';
import Pagging from '@/components/pagging/Paggind';

const CarsPage = () => {
    const [cars, setCars] = useState<Car[]>([]);
    const [pageCount, setPageCount] = useState<number>(0);
    const handlePageNumberChange = (pageNumber: number) => {
        fetchData(pageNumber);
    }

    useEffect(() => {
        const source = axios.CancelToken.source();
        const fetchData = async (pageNumber:number) => {
            try {
                const response = await axios.get<ApiResponse>('https://localhost:7049/Car', {
                    cancelToken: source.token,
                    params:{
                        pageNumber: pageNumber
                    }
                });
                console.log(response);
                setCars(response.data.value.items);
                setPageCount(response.data.value.pageCount);

            } catch (error) {
                console.error(error);
            }
        };

        fetchData(1);

        return () => {
            source.cancel('Operation canceled by the user.');
        };
    }, []);

    const fetchData = async (pageNumber:number) => {
        try {
            const source = axios.CancelToken.source();
            const response = await axios.get<ApiResponse>('https://localhost:7049/Car', {
                cancelToken: source.token,
                params:{
                    pageNumber: pageNumber
                }
            });
            console.log(response);
            setCars(response.data.value.items);
        } catch (error) {
            console.error(error);
        }
    }

    return (
        <div className='page-container'>
            <Header />
            <div className='page-body'>
                <Cars cars={cars} />
                <Pagging pageCount={pageCount} onPageNumberChange={handlePageNumberChange} />
            </div>
            <Footer />
        </div>
    );
};

export default CarsPage;