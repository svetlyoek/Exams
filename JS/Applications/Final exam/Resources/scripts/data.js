const appKey = `81D36362-1CF2-B61B-FFE4-B8B0B7594400`;
const restApiKey = `DF5CED08-5155-4F42-AADB-18E18B972AE4`;

function host(endpoint) {

    return `https://api.backendless.com/${appKey}/${restApiKey}/${endpoint}`;
}

const endpoints = {
    userRegisterUrl: `users/register`,
    userLoginUrl: `users/login`,
    userLogoutUrl: `users/logout`,
    movies: `data/movies`
}

export async function register(email, password) {

    const result = await (await fetch(host(endpoints.userRegisterUrl), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({

            email: email,
            password: password,
        })
    }))
        .json();

    return result;
}

export async function login(email, password) {

    const result = await (await fetch(host(endpoints.userLoginUrl), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({

            login: email,
            password: password
        })
    }))
        .json();

    return result;
}

export async function logout() {

    const token = getToken();

    const result = await (await fetch(endpoints.userLogoutUrl, {
        headers: {
            'user-token': token
        }
    }));

    return result;
}

export async function getMovies(search) {

    const token = getToken();

    let result;

    if (!search) {

        result = await (await fetch(host(endpoints.movies), {
            headers: {
                'user-token': token
            }
        })).json();

    } else {

        result = await (await fetch(host(endpoints.movies + `?where=${escape(`title LIKE '%${search}%'`)}`), {
            headers: {
                'user-token': token
            }
        })).json();
    }

    return result;
}

export async function create(newMovie) {

    const token = getToken();

    const result = await (await fetch(host(endpoints.movies), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(newMovie)
    }))
        .json();

    return result;
}

export async function details(movieId) {

    const token = getToken();

    const result = await (await fetch(host(endpoints.movies + `/${movieId}`), {
        headers: {
            'user-token': token
        }
    })).json();

    return result;
}

export async function edit(movieId, editedMovie) {

    const token = getToken();

    const result = await (await fetch(host(endpoints.movies + `/${movieId}`), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(editedMovie)
    }))
        .json();

    return result;
}

export async function apiDelete(movieId) {

    const token = getToken();

    const result = await (await fetch(host(endpoints.movies + `/${movieId}`), {
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

