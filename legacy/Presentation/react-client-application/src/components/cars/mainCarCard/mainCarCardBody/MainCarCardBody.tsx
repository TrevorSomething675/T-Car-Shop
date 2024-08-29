import styles from './MainCarCardBody.module.css';

const MainCarCardBody:React.FC<{car: Car}> = ({car}) => {
    return <div className={styles.container}>
        <h2>
            {car.name}
        </h2>
        <div className={styles.shortDescription}>
            {car.shortDescription}
        </div>
        <div>
            <div>
                <div className={styles.longDescription}>
                    {car?.description?.longDescription}
                </div>
                <div className={styles.color}>
                    {car?.description?.color}
                </div>
            </div>
        </div>
    </div>
}

export default MainCarCardBody;