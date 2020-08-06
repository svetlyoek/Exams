import * as data from '../scripts/data.js';

export default async function logout() {

    const token = getToken();

    if (!token) {

        alert('You are not authorized!');
        return;
    }

    try {

        const result = await data.logout();

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.app.userData.isLoggedIn = false;
        this.app.userData.username = '';
        this.app.userData.userId = '';
        this.app.userData.userToken = '';

        localStorage.removeItem('userToken');

        this.redirect('#/home');

    } catch (err) {

        console.log(err);
        alert(err);
    }

}
function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}