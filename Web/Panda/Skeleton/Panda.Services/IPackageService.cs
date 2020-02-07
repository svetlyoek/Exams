using Panda.Models;
using Panda.Models.Enums;
using System.Linq;

namespace Panda.Services
{
   public interface IPackageService
    {
        Package Create(Package package);

        IQueryable<Package> GelAllByStatus(PackageStatus status);

        void Deliver(string id);
    }
}
