'use client'

import TopHeader from './topHeader/TopHeader';
import BottomHeader from './bottomHeader/BottomHeader';
import styles from './Header.module.css';

const Header:React.FC<{isSmallHeader?:boolean}> = ({isSmallHeader = false}) => {
    return <>
        <div className={styles.header}>
            <TopHeader isSmallHeader={isSmallHeader}/>
            <BottomHeader />
        </div>
    </>
}

export default Header;