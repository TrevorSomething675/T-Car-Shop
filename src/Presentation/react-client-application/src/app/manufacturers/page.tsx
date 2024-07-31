'use client'

import Header from '@/components/header/Header';
import Footer from '@/components/footer/Footer';
import axios from 'axios';
import Manufacturers from '@/components/manufacturers/Manufacturers';
import { useState, useEffect } from 'react';
import Pagging from '@/components/pagging/Paggind';
import api from '@/http';


const ManufacturersPage = () =>{
    const [manufacturers, setManufacturers] = useState<Manufacturer[]>([])
    const [pageCount, setPageCount] = useState<number>(1);
    const  handlePageNumberChange = (pageNumber: number = 1) =>{
        const source = axios.CancelToken.source();
        fetchData(pageNumber, source);
    }
    const fetchData = async (pageNumber: number = 1, cancelToken: any) => {
        try{
            const response = await api.get<ApiItemsResponse<Manufacturer>>('/Manufacturer', {
                cancelToken: cancelToken.token, 
                params: {
                    pageNumber: pageNumber
                }
            });
            setPageCount(response.data.value.pageCount);
            setManufacturers(response.data.value.items);
        }
        catch(error) {
            
        }
    } 
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
            <Manufacturers manufacturers={manufacturers} />
            <Pagging pageCount={pageCount} onPageNumberChange={handlePageNumberChange}/>
        </div>
        <Footer />
    </div>
}

export default ManufacturersPage;