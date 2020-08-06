import * as data from '../scripts/data.js';

export default async function apiDelete() {

    const token = getToken();

    if (!token) {

        alert('You are not authorized!');
        return;
    }

    try {

        const articleId = this.params.id;
        const result = await data.articleDelete(articleId);

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

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