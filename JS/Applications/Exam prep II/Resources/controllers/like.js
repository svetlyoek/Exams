import { loadError, loadInfo } from '../scripts/notification.js';
import * as data from '../scripts/data.js';

export default async function join() {

    const token = getToken();
    const username = localStorage.getItem('username');

    if (!token) {

        loadError('You are not authorized!');
        return;
    }

    try {

        const recipeId = this.params.id;
        let recipe = this.app.userData.recipes.find(recipe => recipe.objectId == recipeId);

        if (recipe === undefined) {

            recipe = await data.details(recipeId);
        }

        if (!this.app.userData.userRecipes.find(id => id == `${username}-${recipeId}`)) {

            recipe.likes++;

            this.app.userData.userRecipes.push(`${username}-${recipeId}`);

            const result = await data.edit(recipeId, recipe);

            if (result.hasOwnProperty('errorData')) {

                const error = new Error();
                Object.assign(error, result);
                throw error;
            }

            loadInfo('You liked that recipe.');

            this.redirect(`#/details/${recipeId}`);
            
        } else {

            loadInfo('You already liked it!');
        }

    } catch (error) {

        console.log(error);
        loadError(error);
    }
}

function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}