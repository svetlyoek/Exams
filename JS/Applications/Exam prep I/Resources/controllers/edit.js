import { loadError, loadInfo } from '../scripts/notification.js';
import * as data from '../scripts/data.js';

export default async function edit() {

    const token = getToken();

    if (!token) {

        loadError('You are not authorized!');
        return;
    }

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    const eventId = this.params.id;

    let event = this.app.userData.events.find(event => event.objectId == eventId);

    if (event === undefined) {

        event = await data.details(eventId);
    }

    const context = Object.assign(event, this.app.userData);

    this.partial('./partials/events/edit.hbs', context);
}

export async function editPost() {

    const inputName = document.getElementById('inputEventName');
    const inputDate = document.getElementById('inpuEventDate');
    const inputDescription = document.getElementById('inputEventDescription');
    const inputImage = document.getElementById('inputEventImage');

    const name = this.params.name;
    const date = this.params.eventDate;
    const description = this.params.description;
    const image = this.params.image;

    try {

        if (name.length < 6) {

            throw new Error('Name must be at least 6 characters long!');
        }

        if (date.match(`([0-9]+ [A-Za-z]+( - [0-9]+ PM)?)`) == null) {

            throw new Error('Date must be in format: 24 February; 24 March - 10 PM');
        }

        if (description.length < 6) {

            throw new Error('Description must be at least 10 characters long!');
        }

        if (image.match(`^(https:\/\/)`) == null || image.match(`^(http:\/\/)`)) {

            throw new Error('Image url must starts with \'https://\' or \'http://\'');
        }

        const eventId = this.params.id;

        const newEvent = {
            name: name,
            eventDate: date,
            description: description,
            image: image
        }

        const result = await data.edit(eventId, newEvent);

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        inputName.value = '';
        inputDate.value = '';
        inputDescription.value = '';
        inputImage.value = '';

        loadInfo('Event edited successfully');

        this.redirect('#/home');


    } catch (error) {

        console.log(error);
        loadError(error);
    }
}

function getToken() {

    const token = localStorage.getItem('userToken');
    return token;
}