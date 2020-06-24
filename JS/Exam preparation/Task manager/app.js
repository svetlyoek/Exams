function solve() {

    const taskField = document.getElementById('task');
    const descriptionField = document.getElementById('description');
    const dateField = document.getElementById('date');
    const addBtn = document.getElementById('add');

    const openDiv = document.querySelector('.wrapper section:nth-child(2) div:nth-child(2)');
    const progressDiv = document.querySelector('.wrapper section:nth-child(3) div:nth-child(2)');
    const completeDiv = document.querySelector('.wrapper section:nth-child(4) div:nth-child(2)');

    addBtn.addEventListener('click', function (e) {
        e.preventDefault();

        if (taskField.value !== '' && descriptionField.value !== '' && dateField.value !== '') {

            const article = document.createElement('article');
            const heading3 = document.createElement('h3');
            const descriptionParagraph = document.createElement('p');
            const dateParagraph = document.createElement('p');
            const divFlex = document.createElement('div');
            const startBtn = document.createElement('button');
            const deleteBtn = document.createElement('button');
            const finishBtn = document.createElement('button');

            heading3.textContent = taskField.value.trim();
            descriptionParagraph.textContent = `Description: ` + descriptionField.value.trim();
            dateParagraph.textContent = `Due Date: ` + dateField.value.trim();
            startBtn.textContent = 'Start';
            deleteBtn.textContent = 'Delete';
            finishBtn.textContent = 'Finish';

            article.appendChild(heading3);
            article.appendChild(descriptionParagraph);
            article.appendChild(dateParagraph);

            divFlex.classList.add('flex');
            startBtn.classList.add('green');
            deleteBtn.classList.add('red');
            finishBtn.classList.add('orange');

            divFlex.appendChild(startBtn);
            divFlex.appendChild(deleteBtn);

            article.appendChild(divFlex);

            openDiv.appendChild(article);

            document.getElementById('task').value = '';
            document.getElementById('description').value = '';
            document.getElementById('date').value = '';

            startBtn.addEventListener('click', function (e) {

                progressDiv.appendChild(article);
                startBtn.remove();
                divFlex.appendChild(finishBtn);
            });

            finishBtn.addEventListener('click', function (e) {

                completeDiv.appendChild(article);

                divFlex.remove();
            });

            deleteBtn.addEventListener('click', function (e) {

                article.remove();
            });
        }
    });
}