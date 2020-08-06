import * as data from '../scripts/data.js';

export default async function register() {

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    this.partial('./partials/register.hbs', this.app.userData);
}

export async function registerPost() {

    const email = this.params.email;
    const password = this.params.password;
    const repeatPassword = this.params.repeatPassword;

    if (email.length == 0) {

        alert('Email is required!');
        return;
    }

    if (password.length == 0) {

        alert('Password is required!');
        return;
    }

    if (repeatPassword !== password) {

        alert('Passwords do not matches!');
        return;
    }

    try {

        const result = await data.register(email, password);

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.redirect('#/login');

    } catch (err) {

        console.log(err);
        alert(err);
    }
}