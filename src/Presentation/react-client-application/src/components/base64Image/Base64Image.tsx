import styles from './Base64Image.module.css';

const Base64Image : React.FC<{base64String: string}> = ({base64String}) =>{
    return <>
        <img 
            src={`data:image/jpeg;base64,${base64String}`}
            className={styles.image}
        />
    </>    
}

export default Base64Image;