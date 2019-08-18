namespace SpaceStation.Models.Astronauts.Models
{
    public class Meteorologist : Astronaut
    {
        private const double InitialOxygen = 90;

        public Meteorologist(string name)
            : base(name, InitialOxygen)
        {
        }
    }
}
