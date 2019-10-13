namespace SpaceStation.Models.Planets.Models
{
    using SpaceStation.Core;
    using SpaceStation.Messages;
    using System.Collections.Generic;

    public class Planet : IPlanet
    {
        private string name;

        public Planet(string name)
        {
            this.Name = name;
            this.Items = new List<string>();
        }

        public ICollection<string> Items { get; }


        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ValidateStringValueNotNullOrWhiteSpace(value, ExceptionMessages.PlanetNameCanNotBeNullOrWhiteSpace);

                this.name = value;
            }
        }
    }
}
