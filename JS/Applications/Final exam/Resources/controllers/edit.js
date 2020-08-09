import { loadError, loadInfo } from '../scripts/notification.js';
import * as data from '../scripts/data.js';

export default async function edit() {

    const token = getToken();

    if (!token) {

        loadError('You are not authorized!');
        return;
    }

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    const movieId = this.params.id;

    let movie = this.app.userData.movies.find(movie => movie.objectId == movieId);

    if (movie === undefined) {

        movie = await data.details(movieId);
    }

    this.app.userData.ingredients = movie.ingredients;

    const context = Object.assign(movie, this.app.userData);

    this.partial('./partials/movies/edit.hbs', context);
}

export async function editPost() {

    const title = this.params.title;
    const description = this.params.description;
    const image = this.params.image;

    try {

        if (title.length == 0) {

            throw new Error('Title is required!');
        }

        if (description.length == 0) {

            throw new Error('Description is required!');
        }

        if (image.length == 0) {

            throw new Error('Image is required!');
        }

        const movieId = this.params.id;

        const newMovie = {
            title: title,
            description: description,
            image: image,
        }

        const result = await data.edit(movieId, newMovie);

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        loadInfo('Eddited successfully');

        this.redirect(`#/details/${movieId}`);


    } catch (error) {

        console.log(error);
        loadError(error);
    }
}

function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}