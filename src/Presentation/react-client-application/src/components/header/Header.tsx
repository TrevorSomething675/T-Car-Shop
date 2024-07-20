import TopHeader from './topHeader/TopHeader';
import MiddleHeader from './middleHeader/middleHeader';
import BottomHeader from './bottomHeader/BottomHeader';
import styles from './Header.module.css';

const Header = () => {
    return <>
        <div className={styles.header}>
            <TopHeader />
            <MiddleHeader />
            <BottomHeader />
        </div>
    </>
}

export default Header;