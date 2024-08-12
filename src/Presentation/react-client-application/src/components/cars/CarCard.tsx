import Base64Image from '../base64Image/Base64Image';
import styles from './CarCard.module.css';
import Link from 'next/link'
import CurrencyType from '@/models/CurrencyType';
import Offers from '../offers/Offers';
import { toJS } from 'mobx';
import store from '@/store/store';
import SvgFavoriteIcon from '../svgs/favoriteIcon/FavoriteIcon';
import { useState } from 'react';
import axios from 'axios';
import UserCarService from '@/services/UserCarService';
import SvgCartIcon from '../svgs/cartIcon/CartIcon';
import { observer } from 'mobx-react-lite';

const CarCard: React.FC<{car: Car}> = observer(({car}) => {
    const[isFavorite, changeFavoriteState] = useState(car?.userCar[0]?.userId == toJS(store.user.id));
    const changeFavorite = async () => {
        const userCar:UserCar = {
            id: null,
            carId: car.id,
            userId: toJS(store.user.id)
        }
        const source = axios.CancelToken.source();
        if(isFavorite){
            UserCarService.RemoveUserCar(userCar, source.token);
        } else {
            UserCarService.CreateUserCar(userCar, source.token);
        }
        changeFavoriteState(!isFavorite);
    }
    return <div className={styles.car}>
        <Link href={`car/${car.id}`}>
            <Offers offers={car?.offers} />
            {car.images.length > 0 && 
                <Base64Image base64String={car?.images[0].base64String} />
            }
        </Link>
        <div className={styles.cardBotton}>
            <h2 className={styles.h2}>
                {car.name}
            </h2>
            <p className={styles.description}>
                {car.shortDescription}
            </p>
            <div className={styles.footerContainer}>
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
                <div className={styles.offersContainer}>
                {isFavorite ?
                    <button className={styles.favoriteCar} onClick={changeFavorite}>
                        <SvgFavoriteIcon />
                    </button> : 
                    <button className={styles.defaultCar} onClick={changeFavorite}>
                        <SvgFavoriteIcon />
                    </button>
                }
                {store.isAuth &&
                    <button className={styles.cartButtonCar}>
                        <SvgCartIcon />
                    </button>
                }
                </div>
            </div>
        </div>
    </div>
});

export default CarCard;