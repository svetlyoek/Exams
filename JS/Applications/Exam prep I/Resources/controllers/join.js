import { loadError, loadInfo } from '../scripts/notification.js';
import * as data from '../scripts/data.js';

export default async function join() {

    const token = getToken();
    const username = localStorage.getItem('username');

    if (!token) {

        loadError('You are not authorized!');
        return;
    }

    try {

        const eventId = this.params.id;
        let event = this.app.userData.events.find(event => event.objectId == eventId);

        if (event === undefined) {

            event = await data.details(eventId);
        }

        event.people++;

        const result = await data.edit(eventId, event);

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        loadInfo('You join the event successfully.');

        this.redirect(`#/details/${eventId}`);

    } catch (error) {

        console.log(error);
        loadError(error);
    }
}

function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}