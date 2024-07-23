import styles from '@/components/text/Text.module.css';

const Text:React.FC<{text: string}> = ({text}) => {
    console.log(text.split('\n'));
    return <>
        {text.split('\n').map((line, index) => (
            <span key={index} className={styles.textLine}>
                {line}
                {index < text.split('\n').length - 1 && <span><br /><br /></span>}
            </span>
        ))}
    </>
}

export default Text;