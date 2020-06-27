class Article {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {

        if (this._likes.length == 0) {

            return `${this.title} has 0 likes`;

        } else if (this._likes.length == 1) {

            return `${this._likes[0]} likes this article!`;
        } else {

            return `${this._likes[0]} and ${this._likes.length - 1} others like this article!`;
        }
    }

    like(username) {

        if (this._likes.includes(username)) {

            throw new Error(`You can't like the same article twice!`);

        } else if (username == this.creator) {

            throw new Error(`You can't like your own articles!`);
        } else {

            this._likes.push(username);
            return `${username} liked ${this.title}!`;
        }
    }

    dislike(username) {

        if (!this._likes.includes(username)) {

            throw new Error(`You can't dislike this article!`);
        } else {

            const user = this._likes.find(u => u == username);

            this._likes = this._likes.filter(u => u !== user);

            return `${user} disliked ${this.title}`;
        }
    }

    comment(username, content, id) {

        if (id === undefined || this._comments.find(c => c.id == id) === undefined) {

            var comment = {

                id: this._comments.length + 1,
                username: username,
                content: content,
                replies: [],
            };

            this._comments.push(comment);

            return `${username} commented on ${this.title}`;

        } else if (this._comments.find(c => c.id == id) !== undefined) {

            let comment = this._comments.find(c => c.id == id);

            const reply = {

                id: comment.id + `.${comment.replies.length + 1}`,
                username: username,
                content: content
            };

            comment.replies.push(reply);

            return `You replied successfully`;
        }
    }

    toString(sortingType) {

        const result = [

            `Title: ${this.title}`,
            `Creator: ${this.creator}`,
            `Likes: ${this._likes.length}`,
            `Comments:`
        ];

        if (sortingType === 'asc') {

            for (const comment of this._comments.sort((a, b) => a.id - b.id)) {

                result.push(`-- ${comment.id}. ${comment.username}: ${comment.content}`);

                for (const reply of comment.replies.sort((a, b) => a.id - b.id)) {

                    result.push(`--- ${reply.id}. ${reply.username}: ${reply.content}`);
                }
            }


        } else if (sortingType === 'desc') {

            for (const comment of this._comments.sort((a, b) => b.id - a.id)) {

                result.push(`-- ${comment.id}. ${comment.username}: ${comment.content}`);

                for (const reply of comment.replies.sort((a, b) => b.id - a.id)) {

                    result.push(`--- ${reply.id}. ${reply.username}: ${reply.content}`);
                }
            }

        } else if (sortingType === 'username') {

            for (const comment of this._comments.sort((a, b) => a.username.localeCompare(b.username))) {

                result.push(`-- ${comment.id}. ${comment.username}: ${comment.content}`);

                for (const reply of comment.replies.sort((a, b) => a.username.localeCompare(b.username))) {

                    result.push(`--- ${reply.id}. ${reply.username}: ${reply.content}`);
                }
            }
        }

        return result.join('\n');
    }
}

let art = new Article("My Article", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
