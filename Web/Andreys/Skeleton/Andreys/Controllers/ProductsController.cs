using Andreys.Services;
using Andreys.ViewModels.Products;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productService;

        public ProductsController(IProductsService productService)
        {
            this.productService = productService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(ProductCreateInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Name must be between 4 and 20 characters!");
            }

            if (input.Description.Length > 10)
            {
                return this.Error("Description should be up to 10 characters!");
            }

            if (string.IsNullOrWhiteSpace(input.Description))
            {
                return this.Error("Description is required!");
            }

            if (input.Price < 0)
            {
                return this.Error("Price must be a positive number!");
            }

            if (string.IsNullOrWhiteSpace(input.Gender))
            {
                return this.Error("Gender is required!");
            }

            if (string.IsNullOrWhiteSpace(input.Category))
            {
                return this.Error("Category is required!");
            }

            this.productService.Create(input.Name, input.Description, input.ImageUrl, input.Category, input.Gender, input.Price);


            return this.Redirect("/");
        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var productWithDetails = this.productService.GetProductById(id);

            return this.View(productWithDetails);
        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.productService.Delete(id);

            return this.Redirect("/");
        }
    }
}
