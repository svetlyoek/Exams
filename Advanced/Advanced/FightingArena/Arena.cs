namespace FightingArena
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    public class Arena
    {
        private List<Gladiator> gladiators;

        public string Name { get; set; }

        public List<Gladiator> Gladiators { get; set; }
        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public int Count
            => this.gladiators.Count();

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            var currentGladiator = this.Gladiators.Select(n => n).Where(x => x.Name == name).FirstOrDefault();
            this.gladiators.Remove(currentGladiator);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
           return this.Gladiators.OrderByDescending(x => x.GetStatPower()).FirstOrDefault();
           
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
          return this.Gladiators.OrderByDescending(x => x.GetWeaponPower()).FirstOrDefault();
           
        }
        public Gladiator GetGladitorWithHighestTotalPower()
        {
            return this.Gladiators.OrderByDescending(x => x.GetTotalPower()).FirstOrDefault();
           
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"[{this.Name}] - [{Count}] gladiators are participating.");
            return sb.ToString().TrimEnd();
        }
    }
}
