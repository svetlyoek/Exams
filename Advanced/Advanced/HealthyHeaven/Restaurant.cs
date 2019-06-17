namespace HealthyHeaven
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Restaurant
    {
        private List<Salad> data;

        private string name;

        public Restaurant(string name)
        {
            this.name = name;
            this.data = new List<Salad>();
        }

        public List<Salad> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public void Add(Salad salad)
        {
            if (!this.data.Contains(salad))
            {
                this.data.Add(salad);
            }
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

            foreach(var item in data)
            {
                sb.AppendLine($"{item.ToString()}");
            }

            return sb.ToString();
        }
    }
}
