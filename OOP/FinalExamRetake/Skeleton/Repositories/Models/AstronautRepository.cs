namespace SpaceStation.Repositories.Models
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly IList<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models
            => this.astronauts.ToList().AsReadOnly();

        public void Add(IAstronaut model)
        {
            if (!this.astronauts.Any(a => a.Name == model.Name))
            {
                this.astronauts.Add(model);
            }

        }

        public IAstronaut FindByName(string name)
        {
            return this.astronauts.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IAstronaut model)
       => this.astronauts.Remove(model);
    }
}
