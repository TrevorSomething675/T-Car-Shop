import styles from './Cars.module.css';
import CarCard from './CarCard';
import { observer } from 'mobx-react-lite';

const Cars: React.FC<{cars: Car[]}> = observer(({cars}) => {
    return <>
    {cars != undefined &&
        <ul className={styles.ul}>
            {cars.map((car) => 
                <CarCard key={car.id} car={car}/>
            )}
        </ul>
        }
    </>
});

export default Cars;