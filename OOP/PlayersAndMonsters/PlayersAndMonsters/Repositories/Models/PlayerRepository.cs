namespace PlayersAndMonsters.Repositories.Models
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count
            => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players
            => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.PlayerCanNotBeNull);
            }

            if (this.players.Any(n => n.Username == player.Username))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerAlreadyExist, player.Username));
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            var player = this.players.FirstOrDefault(p => p.Username == username);

            return player;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.PlayerCanNotBeNull);
            }
            var IsRemoved = this.players.Remove(player);

            return IsRemoved;
        }
    }
}
