using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitMotorcycle unitMotorcycle;
        private UnitRider unitRider;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
            this.unitMotorcycle = new UnitMotorcycle("Model", 100, 28.8);
            this.unitRider = new UnitRider("Ivan", this.unitMotorcycle);
        }

        [Test]
        public void TestConstructorShouldWorksCorrectly()
        {
            Assert.AreEqual(0, this.raceEntry.Counter);
        }

        [Test]
        public void TestAddRiderShouldWorksCorrectly()
        {
            var unitRider = new UnitRider("Gosho", this.unitMotorcycle);

            this.raceEntry.AddRider(unitRider);

            Assert.AreEqual(1, this.raceEntry.Counter);
        }

        [Test]
        public void TestAddRiderShouldThrowExceptionWhenRiderIsNull()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.AddRider(null);
            });
        }

        [Test]
        public void TestAddRiderShouldThrowExceptionWhenRiderNameIsTheSame()
        {
            var unitRider = new UnitRider("Ivan", this.unitMotorcycle);

            this.raceEntry.AddRider(unitRider);

            Assert.Throws<InvalidOperationException>(() =>
          {
              this.raceEntry.AddRider(unitRider);

          });

        }

        [Test]
        public void TestCalculateAverageHorsePowerShouldWorskCorrectly()
        {
            var unitRider = new UnitRider("Doncho", new UnitMotorcycle("Kawazaki", 50, 75.5));

            this.raceEntry.AddRider(this.unitRider);
            this.raceEntry.AddRider(unitRider);

            double expectedResult = (unitRider.Motorcycle.HorsePower + this.unitRider.Motorcycle.HorsePower) / this.raceEntry.Counter;
            Assert.AreEqual(expectedResult, this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void TestCalculateAverageHorsePowerMustThrowExceptionWhenNoNeededRidersCount()
        {
            this.raceEntry.AddRider(this.unitRider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.CalculateAverageHorsePower();
            });
        }
    }
}