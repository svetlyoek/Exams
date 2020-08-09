export function loadError(message) {

    const errorBox = document.getElementById('errorBox');

    if (errorBox === null) {

        return;
    }

    errorBox.parentNode.style.display = 'block';
    errorBox.textContent = message;

    setInterval(() => {

        errorBox.parentNode.style.display = 'none';

    }, 1000);
}

export function loadInfo(message) {

    const infoBox = document.getElementById('successBox');

    if (infoBox === null) {

        return;
    }

    infoBox.parentNode.style.display = 'block';
    infoBox.textContent = message;

    setInterval(() => {

        infoBox.parentNode.style.display = 'none';

    }, 1000);
}



