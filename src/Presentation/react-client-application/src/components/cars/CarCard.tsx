import Base64Image from '../base64Image/Base64Image';
import styles from './CarCard.module.css';
import Link from 'next/link'
import CurrencyType from '@/models/CurrencyType';
import Offers from '../offers/Offers';

const CarCard: React.FC<{car: Car}> = ({car}) => {
    return <div className={styles.car}>
        <Link href={`car/${car.id}`}>
            <Offers offers={car?.offers} />
            <Base64Image base64String={car.images[0].base64String} />
            <div className={styles.cardBotton}>
                <h2 className={styles.h2}>
                    {car.name}
                </h2>
                <p className={styles.description}>
                    {car.shortDescription}
                </p>
                <div className={styles.priceContainer}>
                    <div className={styles.price}>
                        {car?.price} {CurrencyType[car.currencyType]}
                    </div>
                    {car?.oldPrice != 0 &&
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