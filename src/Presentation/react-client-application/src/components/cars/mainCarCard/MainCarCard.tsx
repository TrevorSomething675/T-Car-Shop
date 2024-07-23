import Base64Image from '@/components/base64Image/Base64Image';
import styles from './MainCarCard.module.css';
import MainCarCardBody from './mainCarCardBody/MainCarCardBody';
import MainCarCardFooter from './mainCarCardFooter/MainCarCardFooter';
import MainCarCardHeader from './mainCarCardHeader/MainCarCardHeader';

const MainCarCard: React.FC<{car: Car}> = ({car}) => {
    return <div className={styles.container}>
        <MainCarCardHeader car={car} />
        <MainCarCardBody car={car}/>
        <MainCarCardFooter car={car}/>
    </div>
}
export default MainCarCard;