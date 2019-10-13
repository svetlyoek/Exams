namespace PlayersAndMonsters.Core.Factories.Models
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Models;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            var playerType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);


            var repository = new CardRepository();

            IPlayer player = (IPlayer)Activator.CreateInstance(playerType, repository, username);

            return player;
        }
    }
}
