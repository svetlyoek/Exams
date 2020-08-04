export function loadError(message) {
    const errorBox = document.getElementById('errorBox');

    if (errorBox === null) {

        return;
    }

    errorBox.style.display = 'block';
    errorBox.textContent = message;

    errorBox.addEventListener('click', hideError);
}

export function loadInfo(message) {
    const infoBox = document.getElementById('successBox');

    if (infoBox === null) {

        return;
    }

    infoBox.style.display = 'block';
    infoBox.textContent = message;

    infoBox.addEventListener('click', hideInfo);

    setInterval(() => {

        infoBox.style.display = 'none';

    }, 5000);
}

export function loading() {
    const loadingBox = document.getElementById('loadingBox');

    if (loadingBox === null) {

        return;
    }

    loadingBox.style.display = 'block';
    loadingBox.textContent = 'Loading...';
}

function hideInfo() {

    infoBox.style.display = 'none';
}

function hideError() {

    errorBox.style.display = 'none';
}