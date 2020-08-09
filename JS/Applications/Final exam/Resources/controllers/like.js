import * as data from '../scripts/data.js';
import { loadError, loadInfo } from '../scripts/notification.js';

export default async function like() {

    const email = localStorage.getItem('email');
    const movieId = this.params.id;

    const movie = await data.details(movieId);

    try {

        if (email == movie.creator) {

            throw new Error('You can not like your own movie!');

        } else {

            movie.peopleLiked.push(email);

            const result = await data.edit(movieId, movie);

            if (result.hasOwnProperty('errorData')) {

                const error = new Error();
                Object.assign(error, result);
                throw error;
            }

            loadInfo('Liked successfully');
        }

        this.redirect(`#/details/${movieId}`)

    } catch (error) {

        console.log(error);
        loadError(error);
    }
}