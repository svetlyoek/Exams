namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;
    using SpaceStation.Models.Planets.Models;
    using SpaceStation.Repositories.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using SpaceStation.Models.Mission.Models;
    using SpaceStation.Factories.Models;
    using SpaceStation.Messages;

    public class Controller : IController
    {
        private AstronautRepository astroRepo;
        private PlanetRepository planetRepo;
        private Mission mission;
        private AstronautFactory factory;
        private List<IPlanet> exploredPlanets;

        public Controller()
        {
            this.planetRepo = new PlanetRepository();
            this.astroRepo = new AstronautRepository();
            this.mission = new Mission();
            this.factory = new AstronautFactory();
            this.exploredPlanets = new List<IPlanet>();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = this.factory.CreateAstronaut(type, astronautName);

            this.astroRepo.Add(astronaut);

            return string.Format(OutputMessages.SuccessfullyAdedAstronaut, astronaut.GetType().Name, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepo.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> astronauts = this.astroRepo
                .Models.Where(a => a.Oxygen > 60)
                .Where(a => a.CanBreath == true)
                .ToList();

            IPlanet planetToExplore = this.planetRepo.FindByName(planetName);

            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.AstronautToExploreMustBeAtLeastOne);
            }

            this.mission.Explore(planetToExplore, astronauts);
            this.exploredPlanets.Add(planetToExplore);

            return string.Format(OutputMessages.PlanetExplored, planetName, astronauts.Where(a => a.CanBreath == false).Count());
        }

        public string Report()
        {

            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.exploredPlanets.Count} planets were explored!")
                .AppendLine("Astronauts info:");

            foreach (IAstronaut astronaut in this.astroRepo.Models)
            {
                result.AppendLine($"Name: {astronaut.Name}")
                    .AppendLine($"Oxygen: {astronaut.Oxygen}");

                if (astronaut.Bag.Items.Count > 0)
                {
                    result.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
                else
                {
                    result.AppendLine($"Bag items: none");

                }

            }

            return result.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astroRepo.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.AstronautDoesNotExists, astronautName));
            }

            this.astroRepo.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
