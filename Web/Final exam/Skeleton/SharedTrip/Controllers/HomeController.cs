namespace SharedTrip.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }

        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                //var allProducts = productsService.GetAll();

                //return this.View(allProducts, "Home");
            }

            return this.View();
        }
    }
}
