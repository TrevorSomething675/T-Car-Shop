import styles from './Cars.module.css';
import Car from './Car';

const Cars: React.FC<{cars: Car[]}> = ({cars}) => {
    return <>
        <ul className={styles.ul}>
            {cars.map((car) => 
                <Car car={car}/>
            )}
        </ul>
    </> 
}

export default Cars;