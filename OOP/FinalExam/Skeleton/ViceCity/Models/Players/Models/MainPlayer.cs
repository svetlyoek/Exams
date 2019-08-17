namespace ViceCity.Models.Players.Models
{
    using ViceCity.Models.Players.Contracts;

    public class MainPlayer : Player, IPlayer
    {
        private const int InitialLifePoints = 100;
        private const string InitialName = "Tommy Vercetti";

        public MainPlayer()
            : base(InitialName, InitialLifePoints)
        {

        }
    }
}
