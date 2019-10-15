function christmasCalculator(input) {
    let budget = Number(input.shift());
    let command = input.shift();
    let sum = 0;
    let enoughBudget = true;
    while (command != 'Stop') {

        for (let i = 0; i < command.length; i++) {
            sum += command.charCodeAt(i);
        }

        if (sum <= budget) {
            budget -= sum;
            console.log(`Item successfully purchased!`);

        }
        else {
            enoughBudget = false;
            break;
        }
        sum = 0;

        command = input.shift();
    }
    if (enoughBudget) {
        console.log(`Money left: ${budget}`);

    }
    else {
        console.log(`Not enough money!`);
    }

}