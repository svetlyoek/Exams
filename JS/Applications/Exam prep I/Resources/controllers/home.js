import * as data from '../scripts/data.js';

export default async function () {

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        event: await this.load('./partials/events/event.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    let events = await data.getEvents();
    events = events.sort((a, b) => b.people - a.people);
    this.app.userData.events = events;
    const context = Object.assign(events, this.app.userData);

    this.partial('./partials/home.hbs', context);
}



