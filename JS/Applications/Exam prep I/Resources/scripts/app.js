/* globals Sammy */

import home from '../controllers/home.js';
import login, { loginPost } from '../controllers/login.js';
import register, { registerPost } from '../controllers/register.js';
import logout from '../controllers/logout.js';
import create, { createPost } from '../controllers/create.js';
import details from '../controllers/details.js';
import edit, { editPost } from '../controllers/edit.js';
import join from '../controllers/join.js';
import deleteEvent from '../controllers/delete.js';
import profile from '../controllers/profile.js';

$(() => {

    const app = Sammy('#main', function () {

        this.use('Handlebars', 'hbs');

        this.userData = {

            events: [],
            userEvents: []
        };

        this.get('index.html', home);
        this.get('/', home);
        this.get('#/home', home);

        this.get('#/login', login);
        this.post('#/login', (context) => { loginPost.call(context) });

        this.get('#/register', register);
        this.post('#/register', (context) => { registerPost.call(context) });

        this.get('#/logout', logout);

        this.get('#/create', create);
        this.post('#/create', (context) => { createPost.call(context) });

        this.get('#/details/:id', details);

        this.get('#/edit/:id', edit);
        this.post('#/edit/:id', (context) => { editPost.call(context) });

        this.get('#/join/:id', join);

        this.get('#/delete/:id', deleteEvent);

        this.get('#/profile', profile);

    });

    app.run();

});