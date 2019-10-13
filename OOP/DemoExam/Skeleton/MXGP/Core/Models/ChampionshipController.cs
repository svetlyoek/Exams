namespace MXGP.Core.Models
{
    using MXGP.Core.Contracts;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Motorcycles.Models;
    using MXGP.Models.Races;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Models.Riders.Models;
    using MXGP.Repositories.Contracts;
    using MXGP.Repositories.Models;
    using MXGP.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Text;
    public class ChampionshipController : IChampionshipController
    {
        private const int MIN_RACERS_COUNT = 3;

        private readonly IRepository<IRider> riderRep;
        private readonly IRepository<IRace> raceRep;
        private readonly IRepository<IMotorcycle> motoRep;

        public ChampionshipController()
        {
            this.riderRep = new RiderRepository();
            this.raceRep = new RaceRepository();
            this.motoRep = new MotorcycleRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riderRep.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            var motor = this.motoRep.GetByName(motorcycleModel);

            if (motor == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motor);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.raceRep.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var rider = this.riderRep.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = null;

            if (this.motoRep.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }

            if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }

            this.motoRep.Add(motorcycle);

            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRep.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            var race = new Race(name, laps);
            this.raceRep.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            if (this.riderRep.GetByName(riderName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            var rider = new Rider(riderName);

            this.riderRep.Add(rider);
            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRep.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var riders = race.Riders
                .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            if (riders.Count < MIN_RACERS_COUNT)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MIN_RACERS_COUNT));
            }

            StringBuilder result = new StringBuilder();

            result.AppendLine($"Rider {riders[0].Name} wins {raceName} race.");
            result.AppendLine($"Rider {riders[1].Name} is second in {raceName} race.");
            result.AppendLine($"Rider {riders[2].Name} is third in {raceName} race.");

            this.raceRep.Remove(race);

            return result.ToString().TrimEnd();
        }
    }
}


