import { loadError } from '../scripts/notification.js';
import * as data from '../scripts/data.js';

export default async function details() {

    const token = getToken();

    if (!token) {

        loadError('You are not authorized!');
        return;
    }

    const username = localStorage.getItem('username');

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    const eventId = this.params.id;

    const event = await data.details(eventId);

    if (username == event.organizer) {

        this.app.userData.isCreator = true;

    } else {

        this.app.userData.isCreator = false;
    }

    const context = Object.assign(event, this.app.userData);

    this.partial('./partials/events/details.hbs', context);
}

function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}