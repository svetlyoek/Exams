import * as data from '../scripts/data.js';

export default async function () {

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        movie: await this.load('./partials/movies/movie.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }
    const search = this.params.search || '';

    let movies = await data.getMovies(search);
    this.app.userData.movies = movies;

    const context = Object.assign({ movies, search }, this.app.userData);

    this.partial('./partials/home.hbs', context);
}



