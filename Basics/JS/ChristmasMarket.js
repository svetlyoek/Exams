function charityMarket(input) {
    let neededMoney = Number(input.shift());
    let fantasyBooksCount = Number(input.shift());
    let hororBooksCount = Number(input.shift());
    let romanticBooksCount = Number(input.shift());

    let allBooksSum = (fantasyBooksCount * 14.90) + (hororBooksCount * 9.80) + (romanticBooksCount * 4.30);
    let realBooksSum = allBooksSum - (allBooksSum * 0.20);
    let sellerSum = 0;
    if (realBooksSum > neededMoney) {
        let diffSum = realBooksSum - neededMoney;
        sellerSum = Math.floor(diffSum * 0.10);
        let realDiffSum = diffSum - sellerSum;
        neededMoney += realDiffSum;
    }

    if (realBooksSum >= neededMoney) {
        console.log(`${neededMoney.toFixed(2)} leva donated.`);
        console.log(`Sellers will receive ${sellerSum} leva.`)
    }
    else {
        let money = neededMoney - realBooksSum;
        console.log(`${money.toFixed(2)} money needed.`);
    }
}

charityMarket([200, 15, 10, 5]);