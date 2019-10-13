function moneyCalculator(input) {
    let baklavaPricePerKg = Number(input.shift());
    let muffinPricePerkg = Number(input.shift());
    let allShtollenKg = Number(input.shift());
    let allSweetsKg = Number(input.shift());
    let allBiscuitsKg = Number(input.shift());

    let shtollenPrice = baklavaPricePerKg + (baklavaPricePerKg * 0.6);
    let sweetsPrice = muffinPricePerkg + (muffinPricePerkg * 0.8);
    let allBiscuitPrice = allBiscuitsKg * 7.50;
    let allShtollenPrice = shtollenPrice * allShtollenKg;
    let allSweetsPrice = sweetsPrice * allSweetsKg;
    let finalPrice = allBiscuitPrice + allShtollenPrice + allSweetsPrice;
    console.log(finalPrice.toFixed(2));
}
moneyCalculator([6.90, 4.20, 1.5, 2.5, 1]);