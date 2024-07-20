import Base64Image from '../base64Image/Base64Image';
import styles from './CarCard.module.css';
import Link from 'next/link'

const CarCard: React.FC<{car: Car}> = ({car}) => {
    return <div className={styles.car}>
        <Link href={`car/${car.id}`}>
            <Base64Image base64String={car.images[0].base64String} />
            <div className={styles.cardBotton}>
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
                    {
                        car.oldPrice != 0 &&
                        <div className={styles.oldPrice}>
                        {car.oldPrice}
                    </div>
                    }
                </div>
            </div>
        </Link>
    </div>
}

export default CarCard;