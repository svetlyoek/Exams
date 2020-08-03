import { loadError, loadInfo } from '../scripts/notification.js';
import * as data from '../scripts/data.js';

export default async function register() {

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    this.partial('./partials/register.hbs', this.app.userData);
}

export async function registerPost() {

    const username = this.params.username;
    const password = this.params.password;
    const rePassword = this.params.rePassword;

    try {

        if (username.length < 3) {

            throw new Error('Username should be at least 3 characters long!');
        }

        if (password.length < 6) {

           throw new Error('Password should be at least 6 characters long!');
        }

        if (rePassword !== password) {

            throw new Error('Passwords do not matches!');
        }

        const result = await data.register(username, password);

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        loadInfo('User registration successful');

        this.redirect('#/login');

    } catch (error) {

        console.log(error);
        loadError(error);
    }
}

