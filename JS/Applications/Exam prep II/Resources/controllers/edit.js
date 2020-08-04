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

    const recipeId = this.params.id;

    let recipe = this.app.userData.recipes.find(recipe => recipe.objectId == recipeId);

    if (recipe === undefined) {

        recipe = await data.details(recipeId);
    }

    this.app.userData.ingredients = recipe.ingredients;

    const context = Object.assign(recipe, this.app.userData);

    this.partial('./partials/recipes/edit.hbs', context);
}

export async function editPost() {

    const inputMeal = document.getElementById('defaultRecepieEditMeal');
    const inputIngredients = document.getElementById('defaultRecepieEditIngredients');
    const inputMethod = document.getElementById('defaultRecepieEditMethodOfPreparation');
    const inputDescription = document.getElementById('defaultRecepieEditDescription');
    const inputImage = document.getElementById('defaultRecepieEditFoodImageURL');

    const meal = this.params.meal;
    const ingredients = this.params.ingredients;
    const method = this.params.method;
    const description = this.params.description;
    const image = this.params.image;
    const category = this.params.category;

    try {

        if (meal.length < 4) {

            throw new Error('Meal must be at least 4 characters long!');
        }

        if (ingredients.length < 2) {

            throw new Error('Ingredients must be at least 2 elements!');
        }

        if (method.length < 10) {

            throw new Error('Description must be at least 10 characters long!');
        }

        if (description.length < 10) {

            throw new Error('Description must be at least 10 characters long!');
        }

        if (image.match(`^(https:\/\/)`) == null || image.match(`^(http:\/\/)`)) {

            throw new Error('Image url must starts with \'https://\' or \'http://\'');
        }

        const recipeId = this.params.id;

        const newRecipe = {
            meal: meal,
            ingredients: ingredients,
            method: method,
            description: description,
            image: image,
            category: category,
        }

        if (category == 'Vegetables and legumes/beans') {

            newRecipe.categoryImage = `https://static1.squarespace.com/static/575737bc40261ddcdeb85179/5ce5b51dee6eb023ab6bda97/5d6546b3d6a19400011c65ce/1569128440434/veg+and+beans.jpg?format=1500w`;

        } else if (category == 'Fruits') {

            newRecipe.categoryImage = `https://c.ndtvimg.com/2020-02/62g4cav_diet_625x300_05_February_20.jpg`;

        } else if (category == 'Grain Food') {

            newRecipe.categoryImage = `https://imageresizer.static9.net.au/f62TCT8O6mYEOWrbRQMcpmsDFxc=/600x338/smart/https%3A%2F%2Fprod.static9.net.au%2F_%2Fmedia%2F2018%2F06%2F19%2F14%2F44%2F180619_coach_whole_grains_1.jpg`;

        } else if (category == 'Milk, cheese, eggs and alternatives') {

            newRecipe.categoryImage = `https://media.wsimag.com/attachments/e93e9eb9c2850d7ffe69d0383ed27baf224eafd3/store/fill/690/388/35defd11ef8de6b2a0af60645188fd44f1fdcc1e7ed397421e56f58cd7c7/Eggs-milk-and-cheese.jpg`;

        } else if (category == 'Lean meats and poultry, fish and alternatives') {

            newRecipe.categoryImage = `https://3.bp.blogspot.com/-Z4UmIJy7wjc/V3YQTrz98BI/AAAAAAAAAMM/BZJHRGrZfTkIPUX3dOeAAiOJ6PcwGMyBwCKgB/s1600/lean-meats.jpg`;
        }

        const result = await data.edit(recipeId, newRecipe);

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        inputMeal.value = '';
        inputIngredients.value = '';
        inputMethod.value = '';
        inputDescription.value = '';
        inputImage.value = '';

        loadInfo('Recipe edited successfully');

        this.redirect(`#/details/${recipeId}`);


    } catch (error) {

        console.log(error);
        loadError(error);
    }
}

function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}