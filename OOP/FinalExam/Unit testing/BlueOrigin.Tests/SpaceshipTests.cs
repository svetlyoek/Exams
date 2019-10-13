namespace BlueOrigin.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship spaceship;
        private List<Astronaut> astronauts;

        [SetUp]
        public void SetUp()
        {
            this.spaceship = new Spaceship("Name", 1);
            this.astronauts = new List<Astronaut>();
        }

        [Test]
        public void TestConstructorIfWorksCorrectly()
        {
            Assert.AreEqual("Name", this.spaceship.Name);
            Assert.AreEqual(1, this.spaceship.Capacity);
            Assert.AreEqual(0, this.astronauts.Count);
        }

        [Test]
        public void TestCountShouldWorkCorrectly()
        {
            var astronaut = new Astronaut("Ivan", 20.5);
            this.astronauts.Add(astronaut);

            Assert.AreEqual(1, this.astronauts.Count);
        }

        [Test]
        public void TestSpaceshipNameShouldThrowExceptionWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var spaceship = new Spaceship(null, 13);

            });
        }

        [Test]
        public void TestSpaceshipNameShouldThrowExceptionWhenEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var spaceship = new Spaceship("", 13);

            });
        }

        [Test]
        public void TestSpaceshipCapacityShouldThrowExceptionWhenNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var spaceship = new Spaceship("Dimo", -1);

            });
        }

        [Test]
        public void TestAddShouldThrowExceptionWhenCapacityIsFull()
        {
            var astronaut = new Astronaut("Ivan", 20.5);
            this.spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(new Astronaut("Svetlio", 23.5));
            });
        }

        [Test]
        public void TestAddShouldThrowExceptionWhenAstronautExists()
        {
            this.spaceship = new Spaceship("Name2", 3);
            var astronaut = new Astronaut("Ivan", 20.5);
            this.spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(astronaut);
            });
        }

        [Test]
        public void TestAddShouldWorksCorrectly()
        {
            var spaceship = new Spaceship("Space", 3);

            var astronaut = new Astronaut("Pesho", 20.5);
            var astronaut2 = new Astronaut("Sasho", 20.5);
            this.astronauts.Add(astronaut);
            this.astronauts.Add(astronaut2);

            spaceship.Add(astronaut);
            spaceship.Add(astronaut2);

            Assert.AreEqual(2, this.astronauts.Count);

        }

        [Test]
        public void TestRemoveShouldWorksCorrectly()
        {
            var astronaut = new Astronaut("Ivan", 20.5);
            this.spaceship.Add(astronaut);

            Assert.IsTrue(this.spaceship.Remove(astronaut.Name));

        }

        [Test]
        public void TestRemoveShouldReturnFalseIfNoRemove()
        {
            var astronaut = new Astronaut("Ivan", 20.5);
            this.spaceship.Add(astronaut);

            Assert.IsFalse(this.spaceship.Remove("Dimitar"));

        }

    }
}