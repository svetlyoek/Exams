namespace MortalEngines.Entities.Models
{
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class BaseMachine : IMachine
    {
        private string name;

        private IPilot pilot;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();

        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NullMachineName);
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.NullPilot);
                }

                this.pilot = value;
            }
        }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public double HealthPoints { get; set; }

        public IList<string> Targets { get; private set; }


        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.NullTarget);
            }

            double diff = Math.Abs(this.AttackPoints - target.DefensePoints);

            if (target.HealthPoints - diff < 0)
            {
                target.HealthPoints = 0;
            }

            else
            {
                target.HealthPoints -= diff;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"- {this.Name}");
            result.AppendLine($" *Type: {this.GetType().Name}");
            result.AppendLine($" *Health: {this.HealthPoints:f2}");
            result.AppendLine($" *Attack: {this.AttackPoints:f2}");
            result.AppendLine($" *Defense: {this.DefensePoints:f2}");

            if (Targets.Count == 0)
            {
                result.AppendLine(" *Targets: None");
            }
            else
            {
                result.AppendLine($"*Targets: {string.Join(",", this.Targets)}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
