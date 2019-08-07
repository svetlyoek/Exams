namespace MXGP.Repositories.Models
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly IList<IMotorcycle> motorcycleRepo;

        public MotorcycleRepository()
        {
            this.motorcycleRepo = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model)
        {
            this.motorcycleRepo.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.motorcycleRepo.ToList();
        }

        public IMotorcycle GetByName(string name)
        {
            return this.motorcycleRepo.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(IMotorcycle model)
            => this.motorcycleRepo.Remove(model);
    }
}
