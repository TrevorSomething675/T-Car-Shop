import Search from '@/components/search/Search';
import styles from './middleHeader.module.css';

const MiddleHeader = () => {
    return <div className={styles.middleHeader}>
        <strong className={styles.logoText}>
            T-Car-Shop
        </strong>
        <div className={styles.searchComponent}>
            <Search />
        </div>
    </div>
}

export default MiddleHeader; 