import styles from './MainCarCardHeader.module.css';
import Base64Image from '@/components/base64Image/Base64Image';

const MainCarCardHeader:React.FC<{car: Car}> = ({car}) => {
    if(car.images.length > 0)
    {
        return <div className={styles.container}>
            <div className={styles.bigImage}>
                <Base64Image base64String={car.images[0].base64String} />
            </div>
            <div className={styles.imageContainer}>
                {car.images.map((image) => 
                    <div className={styles.smallImage}>
                        <Base64Image base64String={image.base64String}/>
                    </div>
                )}
            </div>
        </div> 
    }
}

export default MainCarCardHeader;