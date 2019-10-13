namespace PlayersAndMonsters.Core.Factories.Models
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    public class CardFactory : ICardFactory
    {
        private const string Suffix = "Card";

        public ICard CreateCard(string type, string name)
        {
            var cardType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type + Suffix);


            ICard card = (ICard)Activator.CreateInstance(cardType, name);

            return card;
        }
    }
}
