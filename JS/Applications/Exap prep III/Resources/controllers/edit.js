import * as data from '../scripts/data.js';

export default async function edit() {

    const token = getToken();

    if (!token) {

        alert('You are not authorized!');
        return;
    }

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    const articleId = this.params.id;
    const article = await data.details(articleId);

    const context = Object.assign(article, this.app.userData);

    this.partial('./partials/articles/edit.hbs', context);
}

export async function editPost() {

    const categories = ['JavaScript', 'C#', 'Java', 'Python'];

    const articleId = this.params.id;

    const titleInput = document.getElementById('title');
    const categoryInput = document.getElementById('category');
    const contentInput = document.getElementById('content');

    const title = this.params.title;
    const category = this.params.category;
    const content = this.params.content;

    if (title.length == 0) {

        alert('Title is required!');
        return;
    }

    if (!categories.find(c => c == category)) {

        alert('Allowed categories are: JavaScript, C#, Java, Python');
        return;
    }

    if (content.length == 0) {

        alert('Content is required!');
        return;
    }

    try {

        const editedArticle = {
            title: title,
            category: category,
            content: content,
        }

        const result = await data.edit(articleId, editedArticle);

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        titleInput.value = '';
        categoryInput.value = '';
        contentInput.value = '';

        this.redirect('#/home');

    } catch (err) {

        console.log(err);
        alert(err);
    }

}

function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}