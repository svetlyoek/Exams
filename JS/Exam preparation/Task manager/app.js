function solve() {

    const taskField = document.getElementById('task');
    const descriptionField = document.getElementById('description');
    const dateFiled = document.getElementById('date');
    const addBtn = document.getElementById('add');

    const addDiv = document.querySelector('.wrapper section:nth-child(1) div:nth-child(2)');
    const openDiv = document.querySelector('.wrapper section:nth-child(2) div:nth-child(2)');
    const progressDiv = document.querySelector('.wrapper section:nth-child(3) div:nth-child(2)');
    const completeDiv = document.querySelector('.wrapper section:nth-child(4) div:nth-child(2)');

    addBtn.addEventListener('click', function (e) {
        e.preventDefault();

        if (taskField.value !== '' && descriptionField.value !== '' && dateFiled.value !== '') {

            const article = document.createElement('article');
            const heading3 = document.createElement('h3');
            const descriptionParagraph = document.createElement('p');
            const dateParagraph = document.createElement('p');
            const divFlex = document.createElement('div');
            const startBtn = document.createElement('button');
            const deleteBtn = document.createElement('button');

            heading3.textContent = taskField.value;
            descriptionParagraph.textContent = descriptionField.value;
            dateParagraph.textContent = dateFiled.value;
            startBtn.textContent = 'Start';
            deleteBtn.textContent = 'Delete';

            article.appendChild(heading3);
            article.appendChild(descriptionParagraph);
            article.appendChild(dateParagraph);

            divFlex.classList.add('flex');
            startBtn.classList.add('green');
            deleteBtn.classList.add('red');

            divFlex.appendChild(startBtn);
            divFlex.appendChild(deleteBtn);

            article.appendChild(divFlex);

            openDiv.appendChild(article);

            document.getElementById('task').value = '';
            document.getElementById('description').value = '';
            document.getElementById('date').value = '';
        }
    });

    openDiv.addEventListener('click', function (e) {

        const pressedBtn = e.target;
        const currentArticle = pressedBtn.closest('article');

        if (pressedBtn.textContent === 'Start') {

            const currStartBtn = currentArticle.querySelector('div.flex button.green');
            const currDeleteBtn = currentArticle.querySelector('div.flex button.red');
            currStartBtn.classList.remove('green');
            currStartBtn.classList.add('red');
            currDeleteBtn.classList.remove('red');
            currDeleteBtn.classList.add('orange');
            currStartBtn.textContent = 'Delete';
            currDeleteBtn.textContent = 'Finish';
            progressDiv.appendChild(currentArticle);

        } else if (pressedBtn.textContent === 'Delete') {

            currentArticle.remove();
        }
    });

    progressDiv.addEventListener('click', function (e) {

        const pressedBtn = e.target;
        const currentArticle = pressedBtn.closest('article');

        if (pressedBtn.textContent === 'Delete') {

            currentArticle.remove();
        } else if (pressedBtn.textContent === 'Finish') {

            const currentDiv = pressedBtn.closest('div');

            currentDiv.remove();

            completeDiv.appendChild(currentArticle);
        }

    });
}