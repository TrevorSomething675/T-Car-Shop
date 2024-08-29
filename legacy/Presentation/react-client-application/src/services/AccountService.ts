import api from '@/http/index';

class AccountService{
    static async UpdatePassword(password:string, newPassword:string, confirmNewPassword:string){
        const formData = new FormData();

        formData.append('Password', password);
        formData.append('NewPassword', newPassword);
        formData.append('ConfirmNewPassword', confirmNewPassword);

        const response = await api.post
    }
    static async UpdateUserName(userName:string, newUserName:string){
        const formData = new FormData();

        formData.append('UserName', userName);
        formData.append('NewUserName', newUserName);

        const response = await api.post
    }
}