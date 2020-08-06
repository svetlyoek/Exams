import * as data from '../scripts/data.js';

export default async function login() {

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    this.partial('./partials/login.hbs', this.app.userData);
}

export async function loginPost() {

    const email = this.params.email;
    const password = this.params.password;

    if (email.length == 0) {

        alert('Email is required!');
        return;
    }

    if (password.length == 0) {

        alert('Email is required!');
        return;
    }

    try {

        const result = await data.login(email, password);

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        localStorage.setItem('userId', result.objectId);
        localStorage.setItem('email', result.email);
        localStorage.setItem('userToken', result['user-token']);

        this.app.userData.isLoggedIn = true;
        this.app.userData.email = result.email;
        this.app.userData.userId = result.objectId;
        this.app.userData.userToken = result['user-token'];

        this.redirect('#/home');

    } catch (err) {

        console.log(err);
        alert(err);
    }
}