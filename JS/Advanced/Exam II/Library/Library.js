class Library {
    constructor(libraryName) {
        this.libraryName = libraryName;
        this.subscribers = [];
        this.subscriptionTypes = {

            normal: this.libraryName.length,
            special: this.libraryName.length * 2,
            vip: Number.MAX_SAFE_INTEGER
        };
    }

    subscribe(name, type) {

        if (!this.subscriptionTypes.hasOwnProperty(type)) {

            throw new Error(`The type ${type} is invalid`);

        } else if (this.subscribers.find(s => s.name == name) === undefined) {

            const subscriber = {

                name: name,
                type: type,
                books: []
            };

            this.subscribers.push(subscriber);

            return subscriber;

        } else if (this.subscribers.find(s => s.name == name) !== undefined) {

            let currentSubscriber = this.subscribers.find(s => s.name == name);

            currentSubscriber.type = type;

            return currentSubscriber;
        }
    }

    unsubscribe(name) {

        let subscriber = this.subscribers.find(s => s.name == name);

        if (subscriber === undefined) {

            throw new Error(`There is no such subscriber as ${name}`);

        } else if (subscriber !== undefined) {

            this.subscribers = this.subscribers.filter(s => s.name != subscriber.name);
        }

        return this.subscribers;
    }

    receiveBook(subscriberName, bookTitle, bookAuthor) {

        let subscriber = this.subscribers.find(s => s.name == subscriberName);

        if (subscriber === undefined) {

            throw new Error(`There is no such subscriber as ${subscriberName}`);

        } else if (subscriber !== undefined) {

            let type = subscriber.type;

            if (subscriber.books.length < this.subscriptionTypes[type]) {

                const book = {

                    title: bookTitle,
                    author: bookAuthor
                };

                subscriber.books.push(book);

            } else if (subscriber.books.length >= this.subscriptionTypes[type]) {

                throw new Error(`You have reached your subscription limit ${this.subscriptionTypes[type]}!`);
            }
        }

        return subscriber;
    }

    showInfo() {

        if (this.subscribers.length == 0) {

            return `${this.libraryName} has no information about any subscribers`;
        }

        return this.subscribers
        .map(s =>
            `Subscriber: ${s.name}, Type: ${s.type}\nReceived books: ${s.books
                .map(b =>
                    `${b.title} by ${b.author}`)
                .join(', ')}`)
        .join('\n');
    }
}

let lib = new Library('Lib');

lib.subscribe('Peter', 'normal');
lib.subscribe('John', 'special');

lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
lib.receiveBook('Peter', 'Lord of the rings', 'J. R. R. Tolkien');
lib.receiveBook('John', 'Harry Potter', 'J. K. Rowling');

console.log(lib.showInfo());
