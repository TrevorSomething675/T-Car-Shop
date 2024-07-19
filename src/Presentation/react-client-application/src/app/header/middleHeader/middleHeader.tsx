import Search from '@/components/search/Search';
import styles from './middleHeader.module.css';
import Link from 'next/link';

const MiddleHeader = () => {
    return <div className={styles.middleHeader}>
        <strong className={styles.logoText}>
            <Link href="/" className={styles.link}>
                T-Car-Shop
            </Link>
        </strong>
        <div className={styles.searchComponent}>
            <Search />
        </div>
    </div>
}

export default MiddleHeader; 