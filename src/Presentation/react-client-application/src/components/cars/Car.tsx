import Base64Image from '../base64Image/Base64Image';
import styles from './Car.module.css';

const Car: React.FC<{car: Car}> = ({car}) => {
    return <div className={styles.car}>
        <Base64Image base64String={car.images[0].base64String} />
        <h2 className={styles.h2}>
            {car.name}
        </h2>
        <div className={styles.description}>
            {car.description}
        </div>
        <div className={styles.priceContainer}>
            <div className={styles.price}>
                {car.price}
            </div>
            {car.oldPrice != 0 &&
            <div className={styles.oldPrice}>
                {car.oldPrice}
            </div>
            }
        </div>
    </div>
}

export default Car;