namespace MXGP.Repositories.Models
{
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class RiderRepository : IRepository<IRider>
    {
        private readonly IList<IRider> riderRepo;
        public RiderRepository()
        {
            this.riderRepo = new List<IRider>();
        }

        public void Add(IRider model)
        {
            this.riderRepo.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.riderRepo.ToList();
        }

        public IRider GetByName(string name)
        {
            return this.riderRepo.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRider model)
      => this.riderRepo.Remove(model);
    }
}
