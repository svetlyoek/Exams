function solve() {

    const name = document.querySelectorAll('#add #container input')[0];
    const age = document.querySelectorAll('#add #container input')[1];
    const kind = document.querySelectorAll('#add #container input')[2];
    const owner = document.querySelectorAll('#add #container input')[3];
    const addBtn = document.querySelector('#add #container button');
    const newFriendUl = document.querySelector('#adoption ul');
    const newHomeUl = document.querySelector('#adopted ul');

    addBtn.addEventListener('click', function (e) {
        e.preventDefault();

        const nameValue = name.value.trim();
        const ageValue = age.value.trim();
        const kindValue = kind.value.trim();
        const ownerValue = owner.value.trim();

        if (nameValue !== '' && kindValue !== '' && ownerValue !== '' && ageValue > 0) {


            const list = document.createElement('li');
            const paragraph = document.createElement('p');
            const span = document.createElement('span');
            const contactBtn = document.createElement('button');

            paragraph.innerHTML = `<strong>${nameValue}</strong> is a <strong>${ageValue}</strong> year old <strong>${kindValue}</strong>`;

            list.appendChild(paragraph);

            span.textContent = `Owner: ${ownerValue}`;
            list.appendChild(span);

            contactBtn.textContent = 'Contact with owner';
            list.appendChild(contactBtn);

            newFriendUl.appendChild(list);

            document.querySelectorAll('#add #container input')[0].value = '';
            document.querySelectorAll('#add #container input')[1].value = '';
            document.querySelectorAll('#add #container input')[2].value = '';
            document.querySelectorAll('#add #container input')[3].value = '';

            contactBtn.addEventListener('click', function (e) {

                const div = document.createElement('div');
                const input = document.createElement('input');
                const takeItBtn = document.createElement('button');

                contactBtn.remove();

                input.placeholder = `Enter your names`;

                takeItBtn.textContent = 'Yes! I take it!';

                div.appendChild(input);
                div.appendChild(takeItBtn);

                list.appendChild(div);

                takeItBtn.addEventListener('click', function (e) {

                    var inputName = input.value;
                    const checkedButton = document.createElement('button');

                    if (inputName !== '') {

                        div.removeChild(input);
                        takeItBtn.remove();

                        checkedButton.innerText = 'Checked';
                        list.appendChild(checkedButton);
                        span.innerText = `New Owner: ${inputName}`;

                        newHomeUl.appendChild(list);
                    }

                    checkedButton.addEventListener('click', function (e) {

                        list.remove();
                    });
                });

            });
        }
    });
}
