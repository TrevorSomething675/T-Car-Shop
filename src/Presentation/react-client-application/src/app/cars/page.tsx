'use client'

import React, {useState, useEffect} from 'react' 
import axios from 'axios'
import Cars from '@/components/cars/Cars'

const CarsPage = () => 
{ 
    const [cars, setCars] = useState<Car[]>([]);
    useEffect(() => {
        const fetchData = async () => {
            try{
                const response:ApiResponse = await axios.get('https://localhost:7049/Car');
                console.log(response);
                setCars(response.data.value.items);
            } catch(error){
                console.error(error);
            }
        }
        fetchData();
    }, []);

    return <div>
        <Cars cars={cars}/>
    </div>
};

export default CarsPage;