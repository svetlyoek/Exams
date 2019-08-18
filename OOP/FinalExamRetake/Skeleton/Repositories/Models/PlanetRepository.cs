namespace SpaceStation.Repositories.Models
{
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly IList<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
            => this.planets.ToList().AsReadOnly();

        public void Add(IPlanet model)
        {
            if (!this.planets.Any(p => p.Name == model.Name))
            {
                this.planets.Add(model);
            }

        }

        public IPlanet FindByName(string name)
        {
            return this.planets.FirstOrDefault(p => p.Name == name);
        }

        public bool Remove(IPlanet model)
        => this.planets.Remove(model);
    }
}
