function movieRatings(input) {
    let filmsCount = Number(input.shift());
    let averageRating = 0;
    let allRatings = 0;
    let minRating = Number.MAX_VALUE;
    let maxRating = Number.MIN_VALUE;
    let maxRatingName;
    let minRatingName;
    for (let i = 0; i < filmsCount; i++) {
        let filmName = input.shift();
        let filmRating = Number(input.shift());
        allRatings += filmRating;
        averageRating = allRatings / filmsCount;

        if (filmRating < minRating) {
            minRating = filmRating;
            minRatingName = filmName;
        }
        if (filmRating > maxRating) {
            maxRating = filmRating;
            maxRatingName = filmName;
        }
    }

    console.log(`${maxRatingName} is with highest rating: ${maxRating.toFixed(1)}`);
    console.log(`${minRatingName} is with lowest rating: ${minRating.toFixed(1)}`);
    console.log(`Average rating: ${averageRating.toFixed(1)}`);
}

movieRatings([5,
    'A Star is Born',
    7.8,
    'Creed 2',
    7.3,
    'Mary Poppins',
    7.2,
    'Vice',
    7.2,
    'Captain Marvel',
    7.1
]);

movieRatings([3,
    'Interstellar',
    8.5,
    'Dangal',
    8.3,
    'Green Book',
    8.2

]);