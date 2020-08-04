import * as data from '../scripts/data.js';

export default async function () {

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        recipe: await this.load('./partials/recipes/recipe.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    let recipes = await data.getRecipes();
    this.app.userData.recipes = recipes;
    const context = Object.assign(recipes, this.app.userData);

    this.partial('./partials/home.hbs', context);
}



