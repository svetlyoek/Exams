namespace SpaceStation.Models.Astronauts.Models
{

    public class Geodesist : Astronaut
    {
        private const double InitialOxygen = 50;

        public Geodesist(string name)
            : base(name, InitialOxygen)
        {
        }

    }
}
