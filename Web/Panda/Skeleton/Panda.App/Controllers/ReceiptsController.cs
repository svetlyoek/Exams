using Panda.App.ViewModels.Receipts;
using Panda.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System.Linq;

namespace Panda.App.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptsController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var receipts = this.receiptService.GetAllReceipts()
                .Select(r => new ReceiptDetailsModel
                {
                    Id = r.Id,
                    Fee = r.Fee,
                    IssuedOn = r.IssuedOn,
                    RecipientName = r.Recipient.Username
                })
                .ToList();

            return this.View(receipts);
        }
    }
}
