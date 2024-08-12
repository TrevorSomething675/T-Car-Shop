import { useState } from 'react';
import styles from './MainCarCardFooter.module.css';
import CurrencyType from '@/models/CurrencyType';
import SvgFavoriteIcon from '@/components/svgs/favoriteIcon/FavoriteIcon';
import SvgCartIcon from '@/components/svgs/cartIcon/CartIcon';
import store from '@/store/store';
import { toJS } from 'mobx';
import UserCarService from '@/services/UserCarService';
import axios from 'axios';

const MainCarCardFooter:React.FC<{car: Car}> = ({car}) => {
    const [isFavorite, ChangeFavoriteState] = useState(car?.userCar[0]?.userId == toJS(store.user.id));
    const userCar:UserCar = {
        id: null,
        carId: car.id,
        userId: toJS(store.user.id),
    }
    const source = axios.CancelToken.source();
    if(isFavorite){
        UserCarService.RemoveUserCar(userCar, source.token);
    } else {
        UserCarService.CreateUserCar(userCar, source.token);
    }

    return <div className={styles.container}>
        <div className={styles.priceContainer}>
            <div className={styles.price}>
                {car?.price} {CurrencyType[car.currencyType]}
            </div>
            {car?.oldPrice != 0 &&
                <div className={styles.oldPrice}>
                    {car.oldPrice}
                </div>
            }
        </div>
        <div className={styles.actionContainer}>
            <button className={styles.submitButton}>
                <SvgCartIcon />
                Оставить заявку
            </button>
            {!isFavorite ?
                <button className={styles.favoriteButton} onClick={() => ChangeFavoriteState(!isFavorite)}>
                    <SvgFavoriteIcon />
                    В избранное
                </button> : 
                <button className={styles.defaultButton} onClick={() => ChangeFavoriteState(!isFavorite)}>
                    <SvgFavoriteIcon />
                    В избранном
                </button>
            }
        </div>
    </div>
}

export default MainCarCardFooter;