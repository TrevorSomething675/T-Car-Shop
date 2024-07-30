import styles from './Search.module.css';
import SearchIcon from '../svgs/searchIcon/SearchIcon';

const Search = () => {
    return <div className={styles.container}>
        <button className={styles.searchButton}>
            <SearchIcon />
        </button>
        <input className={styles.searchInput}/>
    </div>
}

export default Search;