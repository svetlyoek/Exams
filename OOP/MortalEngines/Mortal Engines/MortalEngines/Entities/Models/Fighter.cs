namespace MortalEngines.Entities.Models
{
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Fighter : BaseMachine, IFighter
    {
        private const double INITIAL_HEALTH = 200;
        private const double INCREASE_ATTACK_POINTS = 50;
        private const double DECREASE_DEFENSE_POINTS = 25;
        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints + INCREASE_ATTACK_POINTS, defensePoints - DECREASE_DEFENSE_POINTS, INITIAL_HEALTH)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;
                this.AttackPoints += INCREASE_ATTACK_POINTS;
                this.DefensePoints -= DECREASE_DEFENSE_POINTS;
            }
            else
            {
                this.AggressiveMode = false;
                this.AttackPoints -= INCREASE_ATTACK_POINTS;
                this.DefensePoints += DECREASE_DEFENSE_POINTS;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine($" *Aggressive: {(this.AggressiveMode == true ? "ON" : "OFF")}");

            return result.ToString().TrimEnd();
        }
    }
}
