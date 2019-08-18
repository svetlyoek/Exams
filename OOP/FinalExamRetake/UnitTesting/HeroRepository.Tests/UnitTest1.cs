using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HeroRepository.Tests
{
    public class Tests
    {
        private HeroRepository repo;
        private List<Hero> data;

        [SetUp]
        public void Setup()
        {
            this.repo = new HeroRepository();
            this.data = new List<Hero>();
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.data);
        }

        [Test]
        public void TestCreateShouldThrowExceptionIfHeroIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.repo.Create(null);
            });
        }

        [Test]
        public void TestCreateShouldThrowExceptionWhenAlreadyExistsSameHero()
        {
            Hero hero = new Hero("Name", 20);

            this.repo.Create(hero);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.repo.Create(new Hero("Name", 12));
            });
        }

        [Test]
        public void TestCreateShouldAddSuccessfullyHero()
        {
            Hero firstHero = new Hero("Name", 20);
            Hero secondHero = new Hero("Name2", 20);

            this.repo.Create(firstHero);

            this.repo.Create(secondHero);

            this.data.Add(firstHero);
            this.data.Add(secondHero);

            Assert.AreEqual(2, this.data.Count);
        }

        [Test]
        public void TestRemoveShouldThrowExceptionWhenNameIsNull()
        {
            Hero firstHero = new Hero("Name", 20);
            Hero secondHero = new Hero("Name2", 20);

            this.repo.Create(firstHero);

            this.repo.Create(secondHero);

            this.data.Add(firstHero);
            this.data.Add(secondHero);

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.repo.Remove(null);
            });
        }

        [Test]
        public void TestRemoveShouldThrowExceptionWhenNameIsWhiteSpace()
        {
            Hero firstHero = new Hero("Name", 20);
            Hero secondHero = new Hero("Name2", 20);

            this.repo.Create(firstHero);

            this.repo.Create(secondHero);

            this.data.Add(firstHero);
            this.data.Add(secondHero);

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.repo.Remove(" ");
            });
        }

        [Test]
        public void TestRemoveShouldWorksCorrectlyAndReturnTrue()
        {
            Hero firstHero = new Hero("Name", 20);
            Hero secondHero = new Hero("Name2", 20);

            this.repo.Create(firstHero);

            this.repo.Create(secondHero);

            this.data.Add(firstHero);
            this.data.Add(secondHero);

            Assert.IsTrue(this.repo.Remove("Name"));
        }

        [Test]
        public void TestGetHeroWithHighestLevelShouldWorksCorrectly()
        {
            Hero firstHero = new Hero("Name", 20);
            Hero secondHero = new Hero("Name2", 30);

            this.repo.Create(firstHero);

            this.repo.Create(secondHero);

            this.data.Add(firstHero);
            this.data.Add(secondHero);

            Assert.AreEqual(secondHero, this.repo.GetHeroWithHighestLevel());
        }

        [Test]
        public void TestGetHeroShouldWorksCorrectly()
        {
            Hero firstHero = new Hero("Name", 20);
            Hero secondHero = new Hero("Name2", 30);

            this.repo.Create(firstHero);

            this.repo.Create(secondHero);

            this.data.Add(firstHero);
            this.data.Add(secondHero);

            Assert.AreEqual(firstHero, this.repo.GetHero("Name"));
        }

        [Test]
        public void TestHeroIfWorksCorrectly()
        {
            Hero firstHero = new Hero("Name", 20);
            Hero secondHero = new Hero("Name2", 30);

            this.repo.Create(firstHero);

            this.repo.Create(secondHero);

            this.data.Add(firstHero);
            this.data.Add(secondHero);

            CollectionAssert.AreEqual(this.data, this.repo.Heroes);
        }




    }
}