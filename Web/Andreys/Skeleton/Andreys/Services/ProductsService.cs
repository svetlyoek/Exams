using Andreys.Data;
using Andreys.Models;
using Andreys.Models.Enums;
using Andreys.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext context;

        public ProductsService(AndreysDbContext context)
        {
            this.context = context;
        }

        public void Create(string name, string description, string imageUrl, string category, string gender, decimal price)
        {
            var enumCategory = (ProductCategory)Enum.Parse(typeof(ProductCategory), category);
            var enumGender = (Gender)Enum.Parse(typeof(Gender), gender);

            var product = new Product
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Category = enumCategory,
                Gender = enumGender,
                Price = price
            };


            this.context.Products.Add(product);
            this.context.SaveChanges();

        }

        public void Delete(int id)
        {
            var product = this.context.Products.Find(id);

            this.context.Products.Remove(product);

            this.context.SaveChanges();
        }

        public IEnumerable<ProductsViewModel> GetAllProducts()
        {
            var productsViewModel = this.context.Products
                 .Select(p => new ProductsViewModel
                 {
                     Id = p.Id,
                     Name = p.Name,
                     ImageUrl = p.ImageUrl,
                     Price = p.Price
                 })
                 .ToList();

            return productsViewModel;
        }

        public ProductDetailsViewModel GetProductById(int id)
        {
            var product = this.context.Products
                .Where(p => p.Id == id)
                 .Select(p => new ProductDetailsViewModel
                 {
                     Id = id,
                     Name = p.Name,
                     ImageUrl = p.ImageUrl,
                     Category = p.Category,
                     Description = p.Description,
                     Gender = p.Gender,
                     Price = p.Price
                 })
                 .FirstOrDefault();

            return product;
        }
    }
}
