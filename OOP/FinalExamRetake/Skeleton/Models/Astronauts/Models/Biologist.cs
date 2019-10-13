namespace SpaceStation.Models.Astronauts.Models
{

    public class Biologist : Astronaut
    {
        private const double InitialOxygen = 70;
        private const int InitialDecreaseOxygen = 5;

        public Biologist(string name)
            : base(name, InitialOxygen)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - InitialDecreaseOxygen <= 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= InitialDecreaseOxygen;
            }
        }
    }
}
