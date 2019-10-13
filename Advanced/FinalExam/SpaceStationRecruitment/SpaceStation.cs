namespace SpaceStationRecruitment
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
        }

        public int Count => this.data.Count;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add(Astronaut astronaut)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            if (this.data.Any(n => n.Name == name))
            {
                var astronautToRemove = this.data.Select(x => x).Where(n => n.Name == name).FirstOrDefault();
                this.data.Remove(astronautToRemove);
                return true;
            }
            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            var oldest = this.data.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldest;
        }

        public Astronaut GetAstronaut(string name)
        {
            var astronaut = this.data.Select(x => x).Where(n => n.Name == name).FirstOrDefault();

            return astronaut;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in this.data)
            {
                result.AppendLine(astronaut.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
