namespace AquariumAdventure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Aquarium
    {
        private List<Fish> fishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
            this.fishInPool = new List<Fish>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Size { get; set; }

        public void Add(Fish fish)
        {
            if (!this.fishInPool.Any(f => f.Name == fish.Name) && this.fishInPool.Count < this.Capacity)
            {
                this.fishInPool.Add(fish);
            }
        }

        public bool Remove(string name)
        {
            if (this.fishInPool.Any(f => f.Name == name))
            {
                var fishToRemove = this.fishInPool.FirstOrDefault(f => f.Name == name);

                this.fishInPool.Remove(fishToRemove);
                return true;
            }

            return false;
        }

        public Fish FindFish(string name)
        {
            var fishToRemove = this.fishInPool.FirstOrDefault(f => f.Name == name);

            if (this.fishInPool.Contains(fishToRemove))
            {
                return fishToRemove;
            }

            return null;

        }

        public string Report()
        {

            StringBuilder result = new StringBuilder();
            result.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");

            foreach (var fish in this.fishInPool)
            {
                result.AppendLine(fish.ToString());
            }

            return result.ToString().TrimEnd();
        }

    }
}
