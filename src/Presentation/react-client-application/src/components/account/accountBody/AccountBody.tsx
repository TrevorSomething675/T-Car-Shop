import styles from './AccountBody.module.css';

const AccountBody = () => {
    return <div className={styles.container}>
        <div className={styles.leftColumn}>
            <h2 className={styles.h2}>
                Логин
            </h2>
            <form className={styles.form}>
                <div>
                    <label 
                        className={styles.label}
                        htmlFor='name'>Текущий логин:

                    </label>
                    <input 
                        id='name'
                        type='text'
                        className={styles.input}
                        />
                </div>
                <div>
                    <label 
                        className={styles.label}
                        htmlFor='newName'>Новый логин:

                    </label>
                    <input 
                        id='newName'
                        type='text'
                        className={styles.input}
                        />
                </div>
                
            </form>
        </div>
        <div className={styles.rightColumn}>
            <h2 className={styles.h2}>
                Изменение пароля
            </h2>
            <form className={styles.form}>
                <div>
                    <label 
                        className={styles.label}
                        htmlFor='password'>Текущий пароль:

                    </label>
                    <span className={styles.inputContainer}>

                    <input 
                        id='password'
                        type='text'
                        className={styles.input}
                        />
                    </span>
                </div>
                <div>
                    <label 
                        className={styles.label}
                        htmlFor='newPassword'>Новый пароль:

                    </label>
                    <input 
                        id='newPassword'
                        type='text'
                        className={styles.input}
                        />
                </div>
                <div>
                    <label 
                        className={styles.label}
                        htmlFor='confirmNewPassword'>Подтверждение пароля:

                    </label>
                    <input 
                        id='confirmNewPassword'
                        type='text'
                        className={styles.input}
                        />
                </div>
            </form>
        </div>
    </div>
}

export default AccountBody;