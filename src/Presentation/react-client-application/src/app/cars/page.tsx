'use client'

import Header from '@/components/header/Header';
import Footer from '@/components/footer/Footer';
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Cars from '@/components/cars/Cars';
import Pagging from '@/components/pagging/Paggind';
import CarsHeader from '@/components/cars/carsHeader/CarsHeader';
import CarService from '@/services/CarService';
import carStore from '@/store/carStore';
import { toJS } from 'mobx';
import { observer } from 'mobx-react-lite';
import store from '@/store/store';

const CarsPage = observer(() => {
    const fetchData = async (params:any, cancelToken:any) => {
        await CarService.GetCars(params, cancelToken);
    };
    const handlePageNumberChange = (pageNumber:number) => {
        const source = axios.CancelToken.source();
        const params = {
            includes: ['Images', 'Offers'],
            pageNumber: pageNumber,
            userId: toJS(store?.user?.id)
        }
        fetchData(params, source.token);
    };
    
    useEffect(() => {
        if(carStore.carsData?.value === undefined){
            const source = axios.CancelToken.source();
            const params = {
                includes: ['Images', 'Offers'],
                pageNumber: 1,
                userId: toJS(store?.user?.id)
            };
            fetchData(params, source.token);
        }
    }, []);

    return <div className='page-container'>
        <Header />
        <div className='page-body'>
            <CarsHeader />
            <Cars cars={toJS(carStore?.carsData?.value?.items)} />
            <Pagging pageCount={carStore?.carsData?.value?.pageCount} onPageNumberChange={handlePageNumberChange} />
        </div>
        <Footer />
    </div>
});

export default CarsPage;