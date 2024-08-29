import Search from '@/components/search/Search';
import styles from './TopHeader.module.css';
import Link from 'next/link';

const TopHeader:React.FC<{isSmallHeader:boolean}> = ({isSmallHeader}) => {
    return <div className={isSmallHeader ? styles.smallHeader : styles.container}>
        <div className={styles.itemsContainer}>
            <div className={styles.logoText}>
                <Link href="/" className={styles.link}>
                    T-Car-Shop
                </Link>
            </div>
            <div className={styles.searchComponent}>
                <Search />
            </div>
        </div>
    </div>
}

export default TopHeader;