namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilots;
        private readonly List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {

            if (this.pilots.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            else
            {
                IPilot currentPilot = new Pilot(name);
                this.pilots.Add(currentPilot);
                return string.Format(OutputMessages.PilotHired, name);

            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {

            if (this.machines.Any(m => m.Name == name && m.GetType().Name == nameof(Tank)))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                ITank currentTank = new Tank(name, attackPoints, defensePoints);
                this.machines.Add(currentTank);
                return string.Format(OutputMessages.TankManufactured, currentTank.Name, currentTank.AttackPoints, currentTank.DefensePoints);
            }

        }
        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name && m.GetType().Name == nameof(Fighter)))
            {
                return (string.Format(OutputMessages.MachineExists, name));
            }
            else
            {
                IFighter currentFighter = new Fighter(name, attackPoints, defensePoints);
                this.machines.Add(currentFighter);
                return string.Format(OutputMessages.FighterManufactured, currentFighter.Name, currentFighter.AttackPoints, currentFighter.DefensePoints, currentFighter.AggressiveMode
                    == true ? "ON" : "OFF");
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot currentPilot = this.pilots
                .FirstOrDefault(p => p.Name == selectedPilotName);


            if (currentPilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            IMachine currentMachine = this.machines
               .FirstOrDefault(m => m.Name == selectedMachineName);

            if (currentMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);

            }

            if (currentMachine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }


            currentPilot.AddMachine(currentMachine);
            currentMachine.Pilot = currentPilot;

            return string.Format(OutputMessages.MachineEngaged, currentPilot.Name, currentMachine.Name);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attacker = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);

            if (attacker == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            IMachine enemy = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (enemy == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attacker.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            if (enemy.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attacker.Attack(enemy);

            return string.Format(OutputMessages.AttackSuccessful, enemy.Name, attacker.Name, enemy.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            return this.pilots
                 .FirstOrDefault(p => p.Name == pilotReporting).Report();

        }

        public string MachineReport(string machineName)
        {
            return this.machines
                .FirstOrDefault(m => m.Name == machineName).ToString();

        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IFighter currentFighter = (Fighter)this.machines
                .FirstOrDefault(f => f.Name == fighterName && f.GetType().Name == nameof(Fighter));

            if (currentFighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            else
            {
                currentFighter.ToggleAggressiveMode();
                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            ITank currentTank = (Tank)this.machines
                .FirstOrDefault(t => t.Name == tankName && t.GetType().Name == nameof(Tank));

            if (currentTank == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            else
            {
                currentTank.ToggleDefenseMode();
                return string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }
        }
    }
}