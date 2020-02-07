using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Models;
using System;
using System.Linq;

namespace Panda.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly PandaDbContext context;

        public ReceiptService(PandaDbContext context)
        {
            this.context = context;
        }

        public void CreateFromPackage(decimal weight, string packageId, string recipientId)
        {
            var receipt = new Receipt
            {
                PackageId = packageId,
                RecipientId = recipientId,
                IssuedOn = DateTime.UtcNow,
                Fee = weight * 2.67M
            };

            this.context.Receipts.Add(receipt);
            this.context.SaveChanges();

        }

        public IQueryable<Receipt> GetAllReceipts()
        {
            return this.context.Receipts.Include(u => u.Recipient).Select(r => r);
        }
    }
}
