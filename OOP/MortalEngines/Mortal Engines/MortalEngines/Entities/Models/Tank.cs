namespace MortalEngines.Entities.Models
{
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Tank : BaseMachine, ITank
    {
        private const double INITIAL_HEALTH = 100;
        private const double INCREASE_ATTACK_POINTS = 40;
        private const double DECREASE_DEFENSE_POINTS = 30;
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints - INCREASE_ATTACK_POINTS, defensePoints + DECREASE_DEFENSE_POINTS, INITIAL_HEALTH)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefenseMode = true;
                this.AttackPoints -= INCREASE_ATTACK_POINTS;
                this.DefensePoints += DECREASE_DEFENSE_POINTS;
            }
            else
            {
                this.DefenseMode = false;
                this.AttackPoints += INCREASE_ATTACK_POINTS;
                this.DefensePoints -= DECREASE_DEFENSE_POINTS;
               
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine($" *Defense: {(this.DefenseMode == true ? "ON" : "OFF")}");

            return result.ToString().TrimEnd();

        }
    }
}
