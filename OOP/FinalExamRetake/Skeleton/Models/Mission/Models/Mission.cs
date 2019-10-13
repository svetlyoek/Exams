namespace SpaceStation.Models.Mission.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (true)
            {
                IAstronaut astronaut = astronauts
                    .FirstOrDefault(a => a.CanBreath == true);

                if (astronaut == null)
                {
                    break;
                }

                if (planet.Items.Count == 0)
                {
                    break;
                }

                var item = planet.Items.FirstOrDefault();

                if (item == null)
                {
                    break;
                }

                astronaut.Breath();

                astronaut.Bag.Items.Add(item);

                planet.Items.Remove(item);

            }

        }
    }
}
