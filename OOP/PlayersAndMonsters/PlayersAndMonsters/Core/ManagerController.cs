namespace PlayersAndMonsters.Core
{
    using System;

    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerRepository playerRep;
        private readonly ICardRepository cardRep;
        private readonly IPlayerFactory playerFactory;
        private readonly ICardFactory cardFactory;
        private readonly IBattleField battleField;

        public ManagerController(ICardRepository cardRepository,
            IPlayerRepository playerRepository,
            IBattleField battleField,
            ICardFactory cardFactory,
            IPlayerFactory playerFactory)
        {
            this.cardRep = cardRepository;
            this.battleField = battleField;
            this.playerRep = playerRepository;
            this.cardFactory = cardFactory;
            this.playerFactory = playerFactory;
        }

        public string AddPlayer(string type, string username)
        {
            var player = this.playerFactory.CreatePlayer(type, username);
            this.playerRep.Add(player);

            string result = string.Format(ConstantMessages.SuccessfullyAddedPlayer, player.GetType().Name, player.Username);

            return result;
        }

        public string AddCard(string type, string name)
        {
            var card = this.cardFactory.CreateCard(type, name);
            this.cardRep.Add(card);

            string result = string.Format(ConstantMessages.SuccessfullyAddedCard, card.GetType().Name, card.Name);
            return result;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRep.Find(username);
            var card = this.cardRep.Find(cardName);

            player.CardRepository.Add(card);

            string result = string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, card.Name, player.Username);

            return result;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = this.playerRep.Find(attackUser);
            var enemy = this.playerRep.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);

            string result = string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);

            return result;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            foreach (var player in this.playerRep.Players)
            {
                result.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    result.AppendLine(String.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }

                result.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return result.ToString().TrimEnd();
        }
    }
}
