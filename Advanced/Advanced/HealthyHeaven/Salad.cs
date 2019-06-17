namespace HealthyHeaven
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Salad
    {
        private string name;

        private List<Vegetable> products;

        public Salad(string name)
        {
            this.Name = name;
            this.Products = new List<Vegetable>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public List<Vegetable> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public int GetTotalCalories()
        {
            int sum = 0;

            foreach(var veg in products)
            {
                sum += veg.Calories;
            }

            return sum;
        }

        public int GetProductCount()
        {
            return this.Products.Count;
        }

        public void Add(Vegetable product)
        {
            if (!this.Products.Contains(product))
            {
                this.Products.Add(product);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"* Salad {this.Name} is {this.GetTotalCalories()} calories and have {this.GetProductCount()} products: ");

            foreach (var salad in Products)
            {
                sb.AppendLine($"{salad.ToString()}");
            }

            return sb.ToString();
        }
    }
}
