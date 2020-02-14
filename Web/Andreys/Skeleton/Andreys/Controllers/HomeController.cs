namespace Andreys.App.Controllers
{
    using Andreys.Services;
    using Andreys.ViewModels.Products;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly IProductsService productService;

        public HomeController(IProductsService productService)
        {
            this.productService = productService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.View();
            }

            var products = this.productService.GetAllProducts();

            var viewModels = new ProductHomeViewModel
            {
                Products = products
            };

            return this.View(viewModels, "Home");
        }

        [HttpGet("/Home/Index")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }
    }
}
