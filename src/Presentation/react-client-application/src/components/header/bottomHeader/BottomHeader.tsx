import Link from 'next/link';
import styles from './BottomHeader.module.css';

const BottomHeader = () => {
    return <div className = {styles.bottomHeader}>
        <div className={styles.leftNavBar}>
            <ul className={styles.ul}>
                <li className={styles.li}>
                    <Link href="/cars">
                        <button className={styles.button}>Машины</button>
                    </Link>
                </li>
                <li className={styles.li}>
                    <Link href="/brands">
                        <button className={styles.button}>Бренды</button>
                    </Link>
                </li>
                <li className={styles.li}>
                    <button className={styles.button}>Хит продаж</button>
                </li>
                <li className={styles.li}>
                    <button className={styles.button}>Скидки</button>
                </li>
            </ul>
        </div>  
        <div className={styles.rightNavBar}>
            <ul className={styles.ul}>
                <li className={styles.li}>
                    <button className={styles.button}>Уведомления</button>
                </li>
                <li className={styles.li}>
                    <button className={styles.button}>Избранное</button>
                </li>
                <li className={styles.li}>
                    <button className={styles.button}>Личный кабинет</button>
                </li>
            </ul>
        </div>
    </div>
}   

export default BottomHeader;