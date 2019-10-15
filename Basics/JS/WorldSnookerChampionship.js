function ticketCalculator(input) {
    let phase = input.shift();
    let ticketType = input.shift();
    let ticketCount = Number(input.shift());
    let photo = input.shift();

    let ticketsPrice = 0;

    if (ticketType == 'Standard') {
        if (phase == 'Quarter final') {
            ticketsPrice = ticketCount * 55.50;
        }
        else if (phase == 'Semi final') {
            ticketsPrice = ticketCount * 75.88;
        }
        else if (phase == 'Final') {
            ticketsPrice = ticketCount * 110.10;
        }
    }
    else if (ticketType == 'Premium') {
        if (phase == 'Quarter final') {
            ticketsPrice = ticketCount * 105.20;
        }
        else if (phase == 'Semi final') {
            ticketsPrice = ticketCount * 125.22;
        }
        else if (phase == 'Final') {
            ticketsPrice = ticketCount * 160.66;
        }
    }
    else if (ticketType == 'VIP') {
        if (phase == 'Quarter final') {
            ticketsPrice = ticketCount * 118.90;
        }
        else if (phase == 'Semi final') {
            ticketsPrice = ticketCount * 300.40;
        }
        else if (phase == 'Final') {
            ticketsPrice = ticketCount * 400;
        }
    }

    if (ticketsPrice > 2500 && ticketsPrice <= 4000) {
        ticketsPrice -= ticketsPrice * 0.10;
        if (photo == 'Y') {
            ticketsPrice += (ticketCount * 40);
        }

    }
    else if (ticketsPrice > 4000) {
        ticketsPrice -= ticketsPrice * 0.25;
    }
    else if (ticketsPrice <= 2500) {
        if (photo == 'Y') {
            ticketsPrice += (ticketCount * 40)
        }

    }
    console.log(ticketsPrice.toFixed(2))
}
ticketCalculator(['Final', 'Premium', 25, 'Y']);
ticketCalculator(['Semi final', 'VIP', 9, 'Y']);
ticketCalculator(['Quarter final', 'Standard', 11, 'N']);
