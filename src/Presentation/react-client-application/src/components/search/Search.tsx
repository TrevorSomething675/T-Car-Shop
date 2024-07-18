import styles from './Search.module.css';
import SearchIcon from './SearchIcon';

const Search = () => {
    return <div className={styles.search}>
        <div className={styles.searchSection}>
            <button className={styles.searchButton}>
                <SearchIcon />
            </button>
            <input className={styles.searchInput}/>
        </div>
    </div>
}

export default Search;