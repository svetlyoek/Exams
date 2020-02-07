using Panda.App.ViewModels.Packages;
using Panda.Models;
using Panda.Models.Enums;
using Panda.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System;
using System.Linq;

namespace Panda.App.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackageService packageService;
        private readonly IUserService userService;

        public PackagesController(IPackageService packageService, IUserService userService)
        {
            this.packageService = packageService;
            this.userService = userService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var recipients = this.userService.GetAllRecipientsByName();

            return this.View(recipients);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(PackageCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Packages/Create");
            }

            Package package = new Package
            {
                Description = inputModel.Description,
                Weight = inputModel.Weight,
                ShippingAddress = inputModel.ShippingAddress,
                Status = PackageStatus.Pending,
                EstimatedDeliveryDate = DateTime.UtcNow.AddDays(2),
                RecipientId = this.User.Id

            };

            this.packageService.Create(package);

            return this.Redirect("/Packages/Pending");
        }

        [Authorize]
        public IActionResult Pending()
        {
            var pendingPackages = this.packageService.GelAllByStatus(PackageStatus.Pending)
                .Select(p => new PendingPackageDetailsModel
                {
                    Id = p.Id,
                    Description = p.Description,
                    RecipientName = p.Recipient.Username,
                    ShippingAddress = p.ShippingAddress,
                    Weight = p.Weight

                })
                .ToList();

            return this.View(pendingPackages);
        }

        [Authorize]
        public IActionResult Delivered()
        {
            var deliveredPackages = this.packageService.GelAllByStatus(PackageStatus.Delivered)
                .Select(p => new DeliveredPackageDetailsModel
                {
                    Description = p.Description,
                    RecipientName = p.Recipient.Username,
                    ShippingAddress = p.ShippingAddress,
                    Weight = p.Weight,

                })
                .ToList();

            return this.View(deliveredPackages);
        }

        [Authorize]
        public IActionResult Deliver(string id)
        {
            this.packageService.Deliver(id);
            return this.Redirect("/Packages/Delivered");
        }
    }
}
