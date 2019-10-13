namespace ViceCity.Models.Players.Models
{
    using ViceCity.Models.Players.Contracts;

    public class CivilPlayer : Player, IPlayer
    {
        private const int InitialLifePoints = 50;

        public CivilPlayer(string name)
            : base(name, InitialLifePoints)
        {

        }
    }
}
