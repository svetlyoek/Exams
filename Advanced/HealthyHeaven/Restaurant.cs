namespace HealthyHeaven
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Restaurant
    {
        private List<Salad> data;

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
        }

        public List<Salad> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public string Name { get; set; }

        public void Add(Salad salad)
        {

            this.data.Add(salad);

        }

        public bool Buy(string name)
        {
            if (this.data.Where(x => x.Name == name).ToList().Count > 0)
            {
                return true;
            }
            return false;
        }

        public Salad GetHealthiestSalad()
        {
            return this.data.OrderBy(x => x.GetTotalCalories()).First();
        }

        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} have {this.Data.Count} salads:");

            foreach (var item in this.data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
