namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories.Contracts;
    using Repositories.Contracts;
    using IO.Contracts;
    using Models.BattleFields.Contracts;
    using PlayersAndMonsters.IO.Models;
    using PlayersAndMonsters.Repositories.Models;
    using PlayersAndMonsters.Models.BattleFields.Models;
    using PlayersAndMonsters.Core.Factories.Models;

    public class StartUp
    {
        public static void Main()
        {
            ICardRepository cardRep = new CardRepository();
            IPlayerRepository playerRep = new PlayerRepository();
            IBattleField battleField = new BattleField();
            ICardFactory cardFact = new CardFactory();
            IPlayerFactory playerFact = new PlayerFactory();

            IManagerController controller = new ManagerController(cardRep, playerRep, battleField, cardFact, playerFact);

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            var engine = new Engine(controller, reader, writer);
            engine.Run();
        }
    }
}