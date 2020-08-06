import * as data from '../scripts/data.js';

export default async function home() {

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        article: await this.load('./partials/articles/article.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    let newArticles = {
        jsArticles: [],
        cSharpArticles: [],
        javaArticles: [],
        pythonArticles: []
    };

    const articles = await data.getArticles();

    for (let i = 0; i < articles.length; i++) {

        if (articles[i].category == 'JavaScript') {

            if (!newArticles.jsArticles.find(a => a == articles[i])) {

                newArticles.jsArticles.push(articles[i]);
            }

        } else if (articles[i].category == 'C#') {

            if (!newArticles.cSharpArticles.find(a => a == articles[i])) {

                newArticles.cSharpArticles.push(articles[i]);
            }

        } else if (articles[i].category == 'Java') {

            if (!newArticles.javaArticles.find(a => a == articles[i])) {

                newArticles.javaArticles.push(articles[i]);
            }

        } else if (articles[i].category == 'Python') {

            if (!newArticles.pythonArticles.find(a => a == articles[i])) {

                newArticles.pythonArticles.push(articles[i]);
            }
        }
    }

    Object.values(newArticles)
        .forEach(obj => obj.sort((a, b) => (b.title).localeCompare(a.title)));

    const context = Object.assign(newArticles, this.app.userData);

    this.partial('./partials/home.hbs', context);
}