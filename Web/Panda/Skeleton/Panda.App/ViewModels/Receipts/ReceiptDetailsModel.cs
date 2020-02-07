using System;

namespace Panda.App.ViewModels.Receipts
{
   public class ReceiptDetailsModel
    {
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public string RecipientName { get; set; }

    }
}
