import sytles from './Pagging.module.css';
import { useState } from 'react';

const Pagging: React.FC<{pageCount: number, onPageNumberChange: (pageNumber: number) => void}> = ({pageCount, onPageNumberChange}) => {

    let pagesArray = Array.from({length: pageCount}, (_, index) => index + 1);
    const [page, setPage] = useState<number>(pagesArray[0])

    const ChangePageNumber = (pageNumber: number) =>{
        setPage(pageNumber);
        onPageNumberChange(pageNumber);
    }

    return <div className={sytles.paggingContainer}>
        {pagesArray.map((pageNumber) => 
            <button key={pageNumber} className={sytles.button} onClick={() => ChangePageNumber(pageNumber)}>
                {pageNumber}
            </button>
        )}
    </div>
}

export default Pagging;