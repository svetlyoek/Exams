const appKey = `64819D5D-283D-1D99-FF2C-2453A5607300`;
const restApiKey = `1FF2F453-EB43-48F9-A5AD-4B0FAF63067A`;

function host(endpoint) {

    return `https://api.backendless.com/${appKey}/${restApiKey}/${endpoint}`;
}

const endpoints = {

    articles: `data/articles`,
    userRegister: `users/register`,
    userLogin: `users/login`,
    userLogout: `users/logout`
}

export async function getArticles() {

    return await (await fetch(host(endpoints.articles))).json();
}

export async function register(email, password) {

    return await (await fetch(host(endpoints.userRegister), {
        method: 'POST',
        body: JSON.stringify({
            email: email,
            password: password
        })
    }))
        .json();
}

export async function login(email, password) {

    return await (await fetch(host(endpoints.userLogin), {
        method: 'POST',
        body: JSON.stringify({
            login: email,
            password: password
        })
    }))
        .json();
}

export async function logout() {

    const token = getToken();

    return await (await fetch(host(endpoints.userLogout), {
        headers: {
            'user-token': token
        }
    }));
}

export async function create(newArticle) {

    const token = getToken();

    return await (await fetch(host(endpoints.articles), {
        method: 'POST',
        headers: {
            'user-token': token
        },
        body: JSON.stringify(newArticle)
    }))
        .json();
}

export async function details(articleId) {

    const token = getToken();

    return await (await fetch(host(endpoints.articles + `/${articleId}`), {
        headers: {
            'user-token': token
        }
    }))
        .json();
}

export async function edit(articleId, editedArticle) {

    const token = getToken();

    return await (await fetch(host(endpoints.articles + `/${articleId}`), {
        method: 'PUT',
        headers: {
            'user-token': token
        },
        body: JSON.stringify(editedArticle)
    }))
        .json();
}

export async function articleDelete(articleId) {

    const token = getToken();

    return await (await fetch(host(endpoints.articles + `/${articleId}`), {
        method: 'DELETE',
        headers: {
            'user-token': token
        }
    }))
        .json();
}

function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}