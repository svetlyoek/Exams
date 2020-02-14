using Andreys.ViewModels.Products;
using System.Collections.Generic;

namespace Andreys.Services
{
    public interface IProductsService
    {
        IEnumerable<ProductsViewModel> GetAllProducts();

        void Create(string name, string description, string imageUrl, string category, string gender, decimal price);

        ProductDetailsViewModel GetProductById(int id);

        void Delete(int id);
    }
}
