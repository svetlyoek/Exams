namespace MXGP.Models.Motorcycles.Models
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class Motorcycle : IMotorcycle
    {
        private const int MIN_MODEL_SYMBOLS = 4;

        private string model;
        private int horsePower;
        private double cubicCentimeters;

        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public Motorcycle(string model, int horsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_MODEL_SYMBOLS)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, MIN_MODEL_SYMBOLS));
                }
                this.model = value;
            }
        }

        public virtual int HorsePower { get; protected set; }

        public double CubicCentimeters { get; protected set; }


        public double CalculateRacePoints(int laps)
        {
            return (this.CubicCentimeters / this.HorsePower) * laps;
        }
    }
}
