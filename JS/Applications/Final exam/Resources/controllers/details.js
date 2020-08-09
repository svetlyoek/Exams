import { loadError, loadInfo } from '../scripts/notification.js';
import * as data from '../scripts/data.js';

export default async function details() {

    const token = getToken();

    if (!token) {

        loadError('You are not authorized!');
        return;
    }

    const email = localStorage.getItem('email');

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    const movieId = this.params.id;

    const movie = await data.details(movieId);

    if (email == movie.creator) {

        this.app.userData.isCreator = true;

    } else {

        this.app.userData.isCreator = false;
    }

    if (movie.peopleLiked.find(e => e == email)) {

        this.app.userData.isLiked = true;
        this.app.userData.likes = movie.peopleLiked.length;

    } else {

        this.app.userData.isLiked = false;
    }

    const context = Object.assign(movie, this.app.userData);

    this.partial('./partials/movies/details.hbs', context);
}

function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}