function solve() {

    class Article {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {

            return `Title: ${this.title}` + `\n` +
                `Content: ${this.content}`;
        }
    };

    class ShortReports extends Article {
        constructor(title, content, originalResearch) {
            if (!originalResearch['title'] || !originalResearch['author']) {
                throw new Error('The original research should have author and title.');
            } else if (content.length >= 150) {
                throw new Error('Short reports content should be less then 150 symbols.');
            }

            super(title, content);
            this.originalResearch = originalResearch;
            this.comments = [];
        }

        addComment(comment) {

            this.comments.push(comment);

            return `The comment is added.`;
        }

        toString() {

            if (this.comments.length == 0) {

                return super.toString() + `\n` + `Original Research: ${this.originalResearch.title} by ${this.originalResearch.author}`;

            } else if (this.comments.length > 0) {

                return super.toString() + `\n` + `Original Research: ${this.originalResearch.title} by ${this.originalResearch.author}` + `\n` +
                    `Comments:` + `\n` +
                    `${this.comments.map(c => c).join('\n')}`;
            }
        }
    };

    class BookReview extends Article {
        constructor(title, content, book) {
            super(title, content);
            this.book = book;
            this.clients = [];
        }

        addClient(clientName, orderDescription) {

            let currentObj = {
                clientName: clientName,
                orderDescription: orderDescription
            }

            if (this.clients.some(o => o.clientName === clientName && o.orderDescription == orderDescription)) {

                throw new Error('This client has already ordered this review.');
            } else {

                this.clients.push(currentObj);

                return `${currentObj.clientName} has ordered a review for ${this.book.name}`;
            }
        }

        toString() {

            if (this.clients.length == 0) {

                return super.toString() + `\n` + `Book: ${this.book.name}`;

            } else if (this.clients.length > 0) {

                let orders = [];

                for (let obj of this.clients) {

                    let name = obj.clientName;
                    let order = obj.orderDescription;

                    orders.push(`${name} - ${order}`);
                }

                return super.toString() + `\n` + `Book: ${this.book.name}` + '\n' +
                    `Orders:` + '\n' +
                    orders.join('\n');
            }
        }
    };

    return {
        Article,
        ShortReports,
        BookReview
    };
}

let classes = solve();
let lorem = new classes.Article("Lorem", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce non tortor finibus, facilisis mauris vel…");
console.log(lorem.toString());

let short = new classes.ShortReports("SpaceX and Javascript", "Yes, its damn true.SpaceX in its recent launch Dragon 2 Flight has used a technology based on Chromium and Javascript. What are your views on this ?", { title: "Dragon 2", author: "wikipedia.org" });
console.log(short.addComment("Thank god they didn't use java."))
short.addComment("In the end JavaScript\s features are executed in C++ — the underlying language.")
console.log(short.toString());

let book = new classes.BookReview("The Great Gatsby is so much more than a love story", "The Great Gatsby is in many ways similar to Romeo and Juliet, yet I believe that it is so much more than just a love story. It is also a reflection on the hollowness of a life of leisure. ...", { name: "The Great Gatsby", author: "F Scott Fitzgerald" });
console.log(book.addClient("The Guardian", "100 symbols"));
console.log(book.addClient("Goodreads", "30 symbols"));
console.log(book.toString());

