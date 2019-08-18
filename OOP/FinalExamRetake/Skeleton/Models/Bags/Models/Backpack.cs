namespace SpaceStation.Models.Bags.Models
{
    using System.Collections.Generic;

    public class Backpack : IBag
    {
        public Backpack()
        {
            this.Items = new List<string>();
        }

        public ICollection<string> Items { get; private set; }

    }
}
