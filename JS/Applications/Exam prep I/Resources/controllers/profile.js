import { loadError} from '../scripts/notification.js';
import * as data from '../scripts/data.js';

export default async function profile() {

    const token = getToken();
    const ownerId = localStorage.getItem('userId');

    if (!token) {

        loadError('You are not authorized!');
        return;
    }

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    const events = await data.getEvents(ownerId);
    this.app.userData.events = events;
    this.app.userData.eventsCount = events.length;

    const context = Object.assign(events, this.app.userData)

    this.partial('./partials/profile.hbs', context);
}

function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}