using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Models;
using Panda.Models.Enums;
using System.Linq;

namespace Panda.Services
{
    public class PackageService : IPackageService
    {
        private readonly PandaDbContext context;
        private readonly IReceiptService receiptService;


        public PackageService(PandaDbContext context, IReceiptService receiptService)
        {
            this.context = context;
            this.receiptService = receiptService;
        }

        public Package Create(Package package)
        {
            this.context.Packages.Add(package);
            this.context.SaveChanges();
            return package;
        }

        public void Deliver(string id)
        {
            var package = this.context.Packages.Where(p => p.Id == id).FirstOrDefault();

            if (package == null)
            {
                return;
            }

            package.Status = PackageStatus.Delivered;
            this.context.SaveChanges();

            this.receiptService.CreateFromPackage(package.Weight, package.Id, package.RecipientId);
        }

        public IQueryable<Package> GelAllByStatus(PackageStatus status)
        {
            return this.context.Packages.Include(u => u.Recipient).Where(p => p.Status == status);
        }
    }
}
