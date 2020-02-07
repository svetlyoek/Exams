using SIS.MvcFramework.Attributes.Validation;

namespace Panda.App.ViewModels.Packages
{
    public class DeliveredPackageDetailsModel
    {
        private const string DescriptionErrorMessage = "Description must be between 5 and 20 characters!";

        [RequiredSis]
        [StringLengthSis(5, 20, DescriptionErrorMessage)]
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public string RecipientName { get; set; }

    }
}
