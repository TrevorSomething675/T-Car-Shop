import styles from './Cars.module.css';
import CarCard from './CarCard';

const Cars: React.FC<{cars: Car[]}> = ({cars}) => {
    return <>
        <ul className={styles.ul}>
            {cars.map((car) => 
                <CarCard key={car.id} car={car}/>
            )}
        </ul>
    </> 
}

export default Cars;