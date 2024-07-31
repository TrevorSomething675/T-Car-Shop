import styles from './SearchIcon.module.css';

const SvgSeachIcon = () => {
    return <svg className={styles.logo}
         viewBox="0 0 50 50">
        <path d="M21,3C11.6,3,4,10.6,4,20s7.6,17,17,17s17-7.6,17-17S30.4,3,21,3z M21,33c-7.2,0-13-5.8-13-13c0-7.2,5.8-13,13-13c7.2,0,13,5.8,13,13C34,27.2,28.2,33,21,33z"/>
        <line className={styles.logo} x1="31.2" y1="31.2" x2="44.5" y2="44.5"/>
        </svg>
}

export default SvgSeachIcon