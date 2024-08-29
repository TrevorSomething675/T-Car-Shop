import styles from './Offers.module.css';

const Offers:React.FC<{offers: Offers}> = ({offers}) => {
    return <div className={styles.container}>
         <ul className={styles.offersContainer}>
            {offers?.isSale &&
                <li className={styles.saleOffer}>
                    <div className={styles.offerText}>
                        Sale
                    </div>
                </li>
            }
            {offers?.isSell &&
                <li className={styles.sellOffer}>
                    <div className={styles.offerText}>
                        Sold
                    </div>
                </li>
            }
        </ul>
    </div>
}

export default Offers;