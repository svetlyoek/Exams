import * as data from '../scripts/data.js';
import { loadError, loadInfo } from '../scripts/notification.js';

export default async function create() {

    const token = getToken();

    if (!token) {

        loadError('You are not authorized!');
        return;
    }

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }


    this.partial('./partials/movies/create.hbs', this.app.userData);
}

export async function createPost() {

    const email = localStorage.getItem('email');

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

        const newMovie = {
            title: title,
            description: description,
            image: image,
            creator: email,
            peopleLiked: []
        }

        const result = await data.create(newMovie);

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        loadInfo('Created successfully');

        this.redirect('#/home');


    } catch (error) {

        console.log(error);
        loadError(error);
    }
}

function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}