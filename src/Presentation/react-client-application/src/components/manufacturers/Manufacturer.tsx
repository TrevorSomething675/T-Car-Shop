import Base64Image from '../base64Image/Base64Image';
import styles from './Manufacturer.module.css';
import React from 'react';
import AliceCarousel from 'react-alice-carousel';
import 'react-alice-carousel/lib/alice-carousel.css';
import Text from '@/components/text/Text';

const Manufacturer:React.FC<{manufacturer: Manufacturer}> = ({manufacturer}) =>{
    const responsive = {
        0: { items: 1 },
        568: { items: 1 },
        1024: { items: 2 }, 
    }

    return <div className={styles.container}>
        <h2>{manufacturer.name}</h2>
        <div className={styles.description}>
            <Text text={manufacturer.description} />
        </div>
        <div className={styles.imagesContainer}>
            <AliceCarousel items={
                manufacturer.images.map((image) =><Base64Image base64String={image.base64String}/>)} 
                responsive={responsive}
            />
        </div>
        <div className={styles.manufacturerFooter}>
            <div className={styles.manufacturerFooterItem}>
                Контактный номер: {manufacturer.phoneNumber}
            </div>
            <div className={styles.manufacturerFooterItem}>
                Официальный сайт: {manufacturer.officialWebsite}
            </div>
            <div className={styles.manufacturerFooterItem}>
                Город основания: {manufacturer.city}
            </div>
        </div>
    </div>
}

export default Manufacturer;