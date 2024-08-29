import styles from './CarsHeader.module.css';

const CarsHeader = () => {
    return <div className={styles.container}>
        <h2 className={styles.h2}>
            Список автомобилей
        </h2>
        <div className={styles.description}>
            Узнайте больше о модельном ряде автомобилей.
        </div>
    </div>
}

export default CarsHeader;