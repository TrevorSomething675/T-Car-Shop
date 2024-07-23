import styles from './MainCarCardFooter.module.css';
import CurrencyType from '@/models/CurrencyType';

const MainCarCardFooter:React.FC<{car: Car}> = ({car}) => {
    return <div className={styles.container}>
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
        <div className={styles.actionContainer}>
            <button className={styles.submitButton}>
                Оставить заявку
            </button>
            <button className={styles.favoriteButton}>
                В избранное
            </button>
        </div>
    </div>
}

export default MainCarCardFooter;