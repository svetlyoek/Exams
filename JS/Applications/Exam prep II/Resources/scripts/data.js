import { loading } from '../scripts/notification.js';

const appKey = `D284E854-35AB-F76D-FFF2-BD199BB5C100`;
const restApiKey = `CB8C5151-597D-4430-BF66-AA1B3B165FB9`;

function host(endpoint) {

    return `https://api.backendless.com/${appKey}/${restApiKey}/${endpoint}`;
}

const endpoints = {
    userRegisterUrl: `users/register`,
    userLoginUrl: `users/login`,
    userLogoutUrl: `users/logout`,
    recipes: `data/recipes`
}

export async function register(username, password, firstName, lastName) {

    loading();

    const result = await (await fetch(host(endpoints.userRegisterUrl), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({

            username: username,
            password: password,
            firstName: firstName,
            lastName: lastName
        })
    }))
        .json();

    return result;
}

export async function login(username, password) {

    loading();

    const result = await (await fetch(host(endpoints.userLoginUrl), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({

            login: username,
            password: password
        })
    }))
        .json();

    return result;
}

export async function logout() {

    const token = getToken();

    loading();

    const result = await (await fetch(endpoints.userLogoutUrl, {
        headers: {
            'user-token': token
        }
    }));

    return result;
}

export async function getRecipes(ownerId) {

    let result;

    if (!ownerId) {

        result = await (await fetch(host(endpoints.recipes))).json();

    } else {

        result = await (await (await fetch(host(endpoints.recipes + `?where=${escape(`ownerId LIKE '%${ownerId}%'`)}`)))).json();
    }

    return result;
}

export async function create(newRecipe) {

    const token = getToken();

    loading();

    const result = await (await fetch(host(endpoints.recipes), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(newRecipe)
    }))
        .json();

    return result;
}

export async function details(recipeId) {

    const token = getToken();

    loading();

    const result = await (await fetch(host(endpoints.recipes + `/${recipeId}`), {
        headers: {
            'user-token': token
        }
    })).json();

    return result;
}

export async function edit(recipeId, newRecipe) {

    const token = getToken();

    loading();

    const result = await (await fetch(host(endpoints.recipes + `/${recipeId}`), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(newRecipe)
    }))
        .json();

    return result;
}

export async function apiDelete(recipeId) {

    const token = getToken();

    loading();

    const result = await (await fetch(host(endpoints.recipes + `/${recipeId}`), {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        }
    }))
        .json();

    return result;
}

function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}

