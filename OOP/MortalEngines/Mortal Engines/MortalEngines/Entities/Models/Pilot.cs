﻿namespace MortalEngines.Entities.Models
{
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Pilot : IPilot
    {
        private string name;
        private readonly List<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
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
                    throw new ArgumentNullException(ExceptionMessages.NullPilotName);
                }

                this.name = value;
            }
        }


        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException(ExceptionMessages.NullMachine);
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.Name} - {this.machines.Count} machines");

            foreach (IMachine machine in this.machines)
            {
                result.AppendLine(machine.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
