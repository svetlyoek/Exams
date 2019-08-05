namespace MXGP.Repositories.Models
{
    using MXGP.Models.Races.Contracts;
    using MXGP.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IList<IRace> raceRepo;

        public RaceRepository()
        {
            this.raceRepo = new List<IRace>();
        }

        public void Add(IRace model)
        {
            this.raceRepo.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.raceRepo.ToList();
        }

        public IRace GetByName(string name)
        {
            return this.raceRepo.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRace model)
        => this.raceRepo.Remove(model);
    }
}
