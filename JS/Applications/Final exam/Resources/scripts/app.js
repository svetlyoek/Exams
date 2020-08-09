/* globals Sammy */

import home from '../controllers/home.js';
import register, { registerPost } from '../controllers/register.js';
import login, { loginPost } from '../controllers/login.js';
import logout from '../controllers/logout.js';
import create, { createPost } from '../controllers/create.js';
import details from '../controllers/details.js';
import edit, { editPost } from '../controllers/edit.js';
import deleteRecipe from '../controllers/delete.js';
import like from '../controllers/like.js';

$(() => {

    const app = Sammy('#container', function () {

        this.use('Handlebars', 'hbs');

        this.userData = {

            movies: [],
        };

        this.get('indexExam.html', home);
        this.get('/', home);
        this.get('#/home', home);

        this.get('#/register', register);
        this.post('#/register', (context) => { registerPost.call(context) });

        this.get('#/login', login);
        this.post('#/login', (context) => { loginPost.call(context) });


        this.get('#/logout', logout);

        this.get('#/create', create);
        this.post('#/create', (context) => { createPost.call(context) });

        this.get('#/details/:id', details);

        this.get('#/edit/:id', edit);
        this.post('#/edit/:id', (context) => { editPost.call(context) });

        this.get('#/delete/:id', deleteRecipe);

        this.get('#/like/:id', like);
    });

    app.run();

});