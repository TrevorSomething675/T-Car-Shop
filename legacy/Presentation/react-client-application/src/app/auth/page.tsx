import Header from '@/components/header/Header';
import Footer from '@/components/footer/Footer';
import Auth from '@/components/auth/Auth';

const AuthPage = () => {
    return <div className='page-container'>
        <Header isSmallHeader={true}/>
        <div className='page-body'>
            <Auth />
        </div>
        <Footer />
    </div>
};

export default AuthPage;