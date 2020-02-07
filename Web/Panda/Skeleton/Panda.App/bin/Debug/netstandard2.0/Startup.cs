using Panda.Data;
using SIS.MvcFramework;
using SIS.MvcFramework.Routing;
using SIS.MvcFramework.DependencyContainer;
using Panda.Services.User;
using Panda.Services.Package;
using Panda.Services.Receipt;

namespace Panda.App
{
    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var context = new PandaDbContext())
            {
                context.Database.EnsureCreated();
            }
        }


        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUserService, UserService>();
            serviceProvider.Add<IPackageService, PackageService>();
            serviceProvider.Add<IReceiptService, ReceiptService>();
        }
    }
}
