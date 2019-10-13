namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark park;
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.park = new SoftPark();
            this.car = new Car("Make", "Number");
        }

        [Test]
        public void TestConstructorIfWorksCorrectly()
        {
            Assert.AreEqual("Make", this.car.Make);
            Assert.AreEqual("Number", this.car.RegistrationNumber);
        }

        [Test]
        public void TestConstructorShouldNotReturnBeNull()
        {
            Assert.AreEqual(12, this.park.Parking.Count);
        }

        [Test]
        public void TestParkCarShouldThrowExceptionWhenNoCarWithGivenParkLot()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.park.ParkCar("G5", this.car);
            });
        }

        [Test]
        public void TestParkCarShouldThrowExceptionWhenParkLotNotNull()
        {
            this.park.ParkCar("A1", this.car);
            Car car = new Car("Make2", "Number2");

            Assert.Throws<ArgumentException>(() =>
            {
                this.park.ParkCar("A1", this.car);
            });


        }
        [Test]
        public void TestParkCarShouldThrowExceptionWhenCarIsAlreadyParked()
        {
            this.park.ParkCar("A2", this.car);

            Car car = new Car("Make3", "Number");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.park.ParkCar("A3", car);
            });
        }

        [Test]
        public void TestParkCarShouldWorksCorrectly()
        {
            this.park.ParkCar("B1", this.car);

            Car car = new Car("Make4", "Number4");

            Assert.AreEqual($"Car:{car.RegistrationNumber} parked successfully!", this.park.ParkCar("B2", car));
        }

        [Test]
        public void TestRemoveCarShouldThrowExceptionWhenNoCarWithGivenParkLot()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.park.RemoveCar("G5", this.car);
            });
        }

        [Test]
        public void TestRemoveCarShouldThrowExceptionWhenNoCarFoundInThatSpot()
        {
            this.park.ParkCar("B1", this.car);

            Car car = new Car("Make4", "Number4");

            Assert.Throws<ArgumentException>(() =>
            {
                this.park.RemoveCar("B1", car);
            });
        }

        [Test]
        public void TestRemoveCarShouldWorksCorrectly()
        {
            this.park.ParkCar("C3", this.car);

            Assert.AreEqual($"Remove car:{this.car.RegistrationNumber} successfully!", this.park.RemoveCar("C3", this.car));
        }
    }
}