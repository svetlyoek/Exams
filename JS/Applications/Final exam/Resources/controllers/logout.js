import { loadError, loadInfo } from '../scripts/notification.js';
import * as data from '../scripts/data.js';

export default async function logout() {

    const token = getToken();

    if (!token) {

        loadError('You are not authorized!');
        return;
    }

    try {

        const result = await data.logout();

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        loadInfo('Successful logout');

        this.app.userData.isLoggedIn = false;
        this.app.userData.email = '';
        this.app.userData.userId = '';
        this.app.userData.userToken = '';

        localStorage.removeItem('userToken');

        this.redirect('#/login');

    } catch (error) {

        console.log(error);
        loadError(error);
    }
}

function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}