'use client'

import Header from '@/components/header/Header';
import Footer from '@/components/footer/Footer';
import axios from 'axios';
import Manufacturers from '@/components/manufacturers/Manufacturers';
import { useState, useEffect } from 'react';
import Pagging from '@/components/pagging/Paggind';


const ManufacturersPage = () =>{
    const [manufacturers, setManufacturers] = useState<Manufacturer[]>([])
    const [pageCount, setPageCount] = useState<number>(1);
    const  handlePageNumberChange = (pageNumber: number) =>{
        fetchData(pageNumber);
    }
    useEffect(() => {
        const source = axios.CancelToken.source();
        const fetchData = async (pageNumber: number) => {
            try{
                const response = await axios.get<ApiItemsResponse<Manufacturer>>('https://localhost:7049/Manufacturer', {
                    cancelToken: source.token, 
                    params: {
                        pageNumber: pageNumber
                    }
                });
                setPageCount(response.data.value.pageCount);
                setManufacturers(response.data.value.items);
            }
            catch(error) {
                console.error(error);
            }
        } 
        fetchData(1);
    }, []);

    const fetchData = async (pageNumber: number) => {
        const source = axios.CancelToken.source();
        try{
            const response = await axios.get<ApiItemsResponse<Manufacturer>>('https://localhost:7049/Manufacturer', {
                cancelToken: source.token, 
                params: {
                    pageNumber: pageNumber
                }
            });
            setPageCount(response.data.value.pageCount);
            setManufacturers(response.data.value.items);
        }
        catch(error) {
            console.error(error);
        }
    } 

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