namespace ViceCity.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ViceCity.Core.Contracts;
    using ViceCity.Messages;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Guns.Models;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Models.Players.Models;
    using ViceCity.Repositories;

    public class Controller : IController
    {
        private const string MainPlayerFullName = "Tommy Vercetti";
        private const int InitialMainPlayerHealthPoints = 100;

        private readonly GunRepository gunRepo;
        private readonly List<IPlayer> players;
        private readonly GangNeighbourhood neighbourhood;
        private readonly GunFactory gunFactory;

        public Controller()
        {
            this.gunRepo = new GunRepository();
            this.neighbourhood = new GangNeighbourhood();
            this.players = new List<IPlayer>();
            this.gunFactory = new GunFactory();
            this.players.Add(new MainPlayer());
        }

        public string AddGun(string type, string name)
        {
            IGun gun = this.gunFactory.CreateGun(type, name);

            this.gunRepo.Add(gun);

            return string.Format(OutputMessages.SuccessfullyAddedGun, gun.Name, gun.GetType().Name);
        }

        public string AddGunToPlayer(string name)
        {
            if (this.gunRepo.Models.Count == 0)
            {
                return OutputMessages.NoGunsInCollection;
            }

            if (name == "Vercetti")
            {
                IPlayer mainPlayer = this.players.FirstOrDefault(p => p.Name == MainPlayerFullName && p.GetType() == typeof(MainPlayer));

                IGun mainPlayerGun = this.gunRepo.Models.FirstOrDefault(g => g.CanFire == true);

                this.gunRepo.Remove(mainPlayerGun);

                mainPlayer.GunRepository.Add(mainPlayerGun);

                return string.Format(OutputMessages.SuccessfullyAdedGunToPlayer, mainPlayerGun.Name);

            }

            if (this.players.FirstOrDefault(p => p.Name == name) == null)
            {
                return OutputMessages.CivilPlayerDosNotExists;
            }

            IPlayer player = this.players.FirstOrDefault(p => p.Name == name);

            IGun gun = this.gunRepo.Models.FirstOrDefault(g => g.CanFire == true);

            this.gunRepo.Remove(gun);

            player.GunRepository.Add(gun);

            return string.Format(OutputMessages.SuccessfullyAdedGunToCivilPlayer, gun.Name, player.Name);
        }

        public string AddPlayer(string name)
        {
            IPlayer civilPlayer = new CivilPlayer(name);
            this.players.Add(civilPlayer);

            return string.Format(OutputMessages.SuccessfullyAddedCivilPlayer, civilPlayer.Name);
        }

        public string Fight()
        {
            MainPlayer mainPlayer = (MainPlayer)this.players.FirstOrDefault(p => p.GetType().Name == nameof(MainPlayer));

            List<IPlayer> civilPlayers = this.players.Where(p => p.GetType().Name != nameof(MainPlayer)).ToList();

            this.neighbourhood.Action(mainPlayer, civilPlayers);


            StringBuilder result = new StringBuilder();

            if (civilPlayers.Any(p => p.IsAlive == true) && mainPlayer.LifePoints == InitialMainPlayerHealthPoints)
            {
                return OutputMessages.FighIsOk;
            }

            else
            {
                result.AppendLine("A fight happened:")
                        .AppendLine($"Tommy live points: {mainPlayer.LifePoints}!")
                        .AppendLine($"Tommy has killed: {civilPlayers.Where(p => p.IsAlive == false).Count()} players!")
                        .AppendLine($"Left Civil Players: {civilPlayers.Where(p => p.IsAlive == true).Count()}!");

            }

            return result.ToString().TrimEnd();
        }
    }
}
