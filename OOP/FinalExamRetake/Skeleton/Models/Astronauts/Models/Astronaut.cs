namespace SpaceStation.Models.Astronauts.Models
{
    using SpaceStation.Core;
    using SpaceStation.Messages;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags;
    using SpaceStation.Models.Bags.Models;

    public abstract class Astronaut : IAstronaut
    {
        private const int InitialDecreaseOxygen = 10;

        private string name;
        private double oxygen;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ValidateStringValueNotNullOrWhiteSpace(value, ExceptionMessages.AstronautNameCanNotBeNullOrEmpty);

                this.name = value;
            }
        }

        public double Oxygen
        {
            get
            {
                return this.oxygen;
            }

            protected set
            {
                Validator.ValidateDoubleNotNegativeNumber(value, ExceptionMessages.AstronautOxygenCanNotBeNegative);

                this.oxygen = value;
            }
        }

        public bool CanBreath
            => this.Oxygen > 0;


        public IBag Bag { get; private set; }

        public virtual void Breath()
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
