function bachelorParty(input) {

    let singerPrice = Number(input.shift());

    let command = input.shift();
    let people = 0;
    let peoplePrice = 0;
    let totalPeopleCount = 0;

    while (command != 'The restaurant is full') {
        people = Number(command);
        totalPeopleCount += people;
        if (people >= 5) {
            peoplePrice += 70 * people;
        }
        else {
            peoplePrice += 100 * people;
        }
        command = input.shift();
    }


    if (peoplePrice >= singerPrice) {
        console.log(`You have ${totalPeopleCount} guests and ${peoplePrice - singerPrice} leva left.`)
    }
    else {
        console.log(`You have ${totalPeopleCount} guests and ${peoplePrice} leva income, but no singer.`)
    }
}

bachelorParty([2800, 5, 5, 4, 6, 6, 12, 12, 'The restaurant is full']);
bachelorParty([3200, 5, 12, 6, 6, 12, 'The restaurant is full']);