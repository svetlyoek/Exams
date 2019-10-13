namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone("Siemens", "T300");
        }

        [Test]
        public void TestConstructorIfWorksCorrectly()
        {
            Assert.AreEqual("Siemens", this.phone.Make);
            Assert.AreEqual("T300", this.phone.Model);
            Assert.AreEqual(0, this.phone.Count);
        }

        [Test]
        public void TestMakePropertyMustThrowExceptionIfMakeIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Phone("", "T300"));
        }

        [Test]
        public void TestModelPropertyMustThrowExceptionIfModelIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Siemens", null));
        }

        [Test]
        public void TestAddContactShouldThrowExceptionWhenTryToAddSameName()
        {

            this.phone.AddContact("Svetoslav", "Siemens");

            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Svetoslav", "Siemens"));
        }

        [Test]
        public void TestAddContactShouldWorksCorrectly()
        {

            this.phone.AddContact("Svetoslav", "Siemens");

            Assert.AreEqual(1, this.phone.Count);
        }

        [Test]
        public void TestCallShouldThrowExceptionIfTryToCallNotExistingName()
        {
            this.phone.AddContact("Ivan", "333");

            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Dimitar"));
        }

        [Test]
        public void TestCallShouldWorksCorrectly()
        {
            this.phone.AddContact("Ivan", "333");

            Assert.AreEqual("Calling Ivan - 333...", this.phone.Call("Ivan"));
        }
    }
}