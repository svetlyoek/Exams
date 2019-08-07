namespace PlayersAndMonsters.Repositories.Models
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count
            => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards
            => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.CardCanNotBeNull);
            }

            if (this.cards.Any(n => n.Name == card.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CardAlreadyExists, card.Name));
            }

            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            var card = this.cards.FirstOrDefault(p => p.Name == name);

            return card;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.CardCanNotBeNull);
            }

            var IsRemoved = this.cards.Remove(card);

            return IsRemoved;
        }
    }
}
