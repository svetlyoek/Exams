import { loading} from '../scripts/notification.js';

const appKey = `CC2BAC3B-9560-1B72-FFF7-EE7884C95000`;
const restApiKey = `4F4CE76C-9C12-43EE-A061-AEDE4AD01FEC`;

function host(endpoint) {

    return `https://api.backendless.com/${appKey}/${restApiKey}/${endpoint}`;
}

const endpoints = {
    userRegisterUrl: `users/register`,
    userLoginUrl: `users/login`,
    userLogoutUrl: `users/logout`,
    events: `data/events`
}

export async function register(username, password) {

    loading();

    const result = await (await fetch(host(endpoints.userRegisterUrl), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({

            username: username,
            password: password
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

export async function getEvents(ownerId) {

    let result;

    if (!ownerId) {

        result = await (await fetch(host(endpoints.events))).json();

    } else {

        result = await (await (await fetch(host(endpoints.events + `?where=${escape(`ownerId LIKE '%${ownerId}%'`)}`)))).json();
    }

    return result;
}

export async function create(newEvent) {

    const token = getToken();

    loading();

    const result = await (await fetch(host(endpoints.events), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(newEvent)
    }))
        .json();

    return result;
}

export async function details(eventId) {

    const token = getToken();

    loading();

    const result = await (await fetch(host(endpoints.events + `/${eventId}`), {
        headers: {
            'user-token': token
        }
    })).json();

    return result;
}

export async function edit(eventId, newEvent) {

    const token = getToken();

    loading();

    const result = await (await fetch(host(endpoints.events + `/${eventId}`), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(newEvent)
    }))
        .json();

    return result;
}

export async function apiDelete(eventId) {

    const token = getToken();

    loading();

    const result = await (await fetch(host(endpoints.events + `/${eventId}`), {
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

