using Andreys.Models.Enums;

namespace Andreys.ViewModels.Products
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductCategory Category { get; set; }

        public Gender Gender { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
