import styles from './LoginIcon.module.css';

const SvgLoginIcon = () => {
    return <svg className={styles.icon}
    width="1rem" height="1rem" 
     viewBox="0 -1 16 16">
    <path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6"/>
  </svg>
}

export default SvgLoginIcon;