namespace FightingArena
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }
        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            int power = this.GetWeaponPower() + this.GetStatPower();
            return power;
        }
        public int GetWeaponPower()
        {
            int power = this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;
            return power;
        }
        public int GetStatPower()
        {
            int power = this.Stat.Strength + this.Stat.Flexibility + this.Stat.Agility + this.Stat.Skills + this.Stat.Intelligence;
            return power;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"[{this.Name}] - [{GetTotalPower()}]");
            sb.AppendLine($"  Weapon Power: [{GetWeaponPower()}]");
            sb.AppendLine($"  Stat Power: [{GetStatPower()}]");

            return sb.ToString().TrimEnd();
        }
    }
}
