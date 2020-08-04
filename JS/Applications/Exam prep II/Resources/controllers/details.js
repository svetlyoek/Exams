import { loadError } from '../scripts/notification.js';
import * as data from '../scripts/data.js';

export default async function details() {

    const token = getToken();

    if (!token) {

        loadError('You are not authorized!');
        return;
    }

    const username = localStorage.getItem('username');

    this.partials = {
        header: await this.load('./partials/common/header.hbs')
    }

    const recipeId = this.params.id;

    const recipe = await data.details(recipeId);

    if (username == recipe.organizer) {

        this.app.userData.isCreator = true;

    } else {

        this.app.userData.isCreator = false;
    }

    this.app.userData.ingredients = recipe.ingredients;

    const context = Object.assign(recipe, this.app.userData);

    this.partial('./partials/recipes/details.hbs', context);
}

function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}