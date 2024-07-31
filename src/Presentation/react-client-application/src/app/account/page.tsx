import Header from '@/components/header/Header';
import Footer from '@/components/footer/Footer';
import Account from '@/components/account/Account';

const AccountPage = () => {
    return <div className='page-container'>
        <Header isSmallHeader={true}/>
        <div className='page-body'>
            <Account />
        </div>        
        <Footer />
    </div>
};

export default AccountPage;