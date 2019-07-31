namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConstructorTest()
        {
            var phone = new Phone("Siemens", "T300");

            Assert.AreEqual("Siemens", phone.Make);
            Assert.AreEqual("T300", phone.Model);
            Assert.AreEqual(0, phone.Count);
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
            var phone = new Phone("Siemens", "T300");

            phone.AddContact("Svetoslav", "Siemens");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Svetoslav", "Siemens"));
        }

        [Test]
        public void AddContactTest()
        {
            var phone = new Phone("Siemens", "T300");

            phone.AddContact("Svetoslav", "Siemens");

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void CallExceptionTest()
        {
            var phone = new Phone("Siemens", "T300");

            phone.AddContact("Ivan", "333");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Dimitar"));
        }

        [Test]
        public void Calltest()
        {
            var phone = new Phone("Siemens", "T300");

            phone.AddContact("Ivan", "333");

            Assert.AreEqual("Calling Ivan - 333...", phone.Call("Ivan"));
        }
    }
}