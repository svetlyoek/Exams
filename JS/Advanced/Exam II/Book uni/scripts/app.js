function solve() {

    const title = document.querySelectorAll('form input')[0];
    const year = document.querySelectorAll('form input')[1];
    const price = document.querySelectorAll('form input')[2];
    const addBtn = document.querySelector('form button');

    const totalProfit = document.querySelectorAll('h1')[1];
    const oldBooksShelf = document.querySelector('body #outputs section:nth-child(1) .bookShelf');
    const newBooksShelf = document.querySelector('body #outputs section:nth-child(2) .bookShelf');

    let totalSum = 0;

    addBtn.addEventListener('click', function (e) {
        e.preventDefault();

        titleValue = title.value.trim();

       /*  Parse  */
       
        yearValue = Number(year.value);
        priceValue = Number(price.value);

        if (titleValue !== '' && yearValue >= 0 && priceValue >= 0) {

            const div = document.createElement('div');
            div.classList.add('book');

            const paragraph = document.createElement('p');
            const buyItBtn = document.createElement('button');
            const moveBtn = document.createElement('button');

            paragraph.textContent = `${titleValue} [${yearValue}]`;
            div.appendChild(paragraph);

            if (yearValue >= 2000) {

                buyItBtn.textContent = `Buy it only for ${priceValue.toFixed(2)} BGN`;
                moveBtn.textContent = `Move to old section`;
                div.appendChild(buyItBtn);
                div.appendChild(moveBtn);

                newBooksShelf.appendChild(div);

            } else {

                priceValue -= priceValue * 0.15;
                buyItBtn.textContent = `Buy it only for ${priceValue.toFixed(2)} BGN`;
                div.appendChild(buyItBtn);

                oldBooksShelf.appendChild(div);
            }

            moveBtn.addEventListener('click', function (e) {

                priceValue -= priceValue * 0.15;
                buyItBtn.textContent = `Buy it only for ${priceValue.toFixed(2)} BGN`;
                moveBtn.remove();
                oldBooksShelf.appendChild(div);
            });

            buyItBtn.addEventListener('click', function (e) {

                div.remove();
                totalSum += priceValue;

                totalProfit.textContent = `Total Store Profit: ${totalSum.toFixed(2)} BGN`;
               
            });
        }
    });
}