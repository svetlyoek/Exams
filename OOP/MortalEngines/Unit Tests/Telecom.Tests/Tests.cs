namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void ObjectInitialize()
        {
            this.phone = new Phone("Siemens", "T300");
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.AreEqual("Siemens", this.phone.Make);
            Assert.AreEqual("T300", this.phone.Model);
            Assert.AreEqual(0, this.phone.Count);
        }

        [Test]
        public void MakePropertyTest()
        {
            Assert.Throws<ArgumentException>(() => new Phone("", "T300"));
        }

        [Test]
        public void ModelPropertyTest()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Siemens", null));
        }

        [Test]
        public void AddContactExceptionTest()
        {

            this.phone.AddContact("Svetoslav", "Siemens");

            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Svetoslav", "Siemens"));
        }

        [Test]
        public void AddContactTest()
        {

            this.phone.AddContact("Svetoslav", "Siemens");

            Assert.AreEqual(1, this.phone.Count);
        }

        [Test]
        public void CallExceptionTest()
        {
            this.phone.AddContact("Ivan", "333");

            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Dimitar"));
        }

        [Test]
        public void Calltest()
        {
            this.phone.AddContact("Ivan", "333");

            Assert.AreEqual("Calling Ivan - 333...", this.phone.Call("Ivan"));
        }
    }
}