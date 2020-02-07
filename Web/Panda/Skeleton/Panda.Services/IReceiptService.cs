using Panda.Models;
using System.Linq;

namespace Panda.Services
{
    public interface IReceiptService
    {
        void CreateFromPackage(decimal weight, string packageId, string recipientId);

        IQueryable<Receipt> GetAllReceipts();
    }
}
