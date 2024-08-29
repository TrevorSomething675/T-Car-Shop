import styles from './Manufacturers.module.css';
import Manufacturer from './Manufacturer';

const Manufacturers:React.FC<{manufacturers: Manufacturer[]}> = ({manufacturers}) =>{
    return <div className={styles.container}>
        {manufacturers.map((manufacturer) =>
            <Manufacturer key={manufacturer.id} manufacturer={manufacturer}/>
        )}
    </div>
}

export default Manufacturers;