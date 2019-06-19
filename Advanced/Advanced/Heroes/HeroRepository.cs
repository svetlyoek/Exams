namespace Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.Data = new List<Hero>();
        }

        public List<Hero> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public void Add(Hero hero)
        {
            this.Data.Add(hero);
        }

        public void Remove(string name)
        {

            var removedElement = this.Data.Select(x => x).Where(n => n.Name == name).First();

            this.Data.Remove(removedElement);
        }

        public Hero GetHeroWithHighestStrength()
        {
            var hero = this.Data.OrderByDescending(s => s.Item.Strength).FirstOrDefault();
            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            var hero = this.Data.OrderByDescending(a => a.Item.Ability).FirstOrDefault();
            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            var hero = this.Data.OrderByDescending(i => i.Item.Intelligence).FirstOrDefault();
            return hero;
        }

        public int Count => this.Data.Count;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in this.Data)
            {
                sb.AppendLine($"Hero: {hero.Name} – {hero.Level}lvl");
                sb.AppendLine($"Item:");
                sb.AppendLine($"  * Strength: {hero.Item.Strength}");
                sb.AppendLine($"  * Ability: {hero.Item.Ability}");
                sb.AppendLine($"  * Intelligence: {hero.Item.Intelligence}");

            }

            return sb.ToString();
        }
    }
}
