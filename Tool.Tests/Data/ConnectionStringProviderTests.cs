using Moq;
using NUnit.Framework;
using System;
using System.Configuration;
using Tool.Data;

namespace Tool.Tests.Data {

    [TestFixture]
    public class ConnectionStringProviderTests {

        const string NAME = "bar";
        const string VALUE = "some connection";

        IConnectionStringProvider sut;

        [SetUp]
        public void SetUp() {
            var connectionStrings = new ConnectionStringSettingsCollection();
            connectionStrings.Add(new ConnectionStringSettings(NAME, VALUE));
            var mock = new Mock<IConfigurationManagerWrapper>();
            mock.SetupGet(x => x.ConnectionStrings).Returns(connectionStrings);

            sut = new ConnectionStringProvider(mock.Object);
        }

        [TestCase("")]
        [TestCase(null)]
        public void No_Name_Should_Throw_Exception(string name) {
            var ex = Assert.Throws(typeof(ArgumentException), () => sut.Get(name));
            Assert.AreEqual("Not a valid name for a connection string.", ex.Message);
        }

        [Test]
        public void Unknown_Name_Should_Throw_Exception() {
            var ex = Assert.Throws(typeof(ArgumentException), () => sut.Get("foo"));
            Assert.AreEqual("Connectionstring 'foo' was not found.", ex.Message);
        }

        [Test]
        public void Known_name_Should_Return_Correct_ConnectionString() {
            var actual = sut.Get(NAME);
            Assert.AreEqual(VALUE, actual);
        }
    }
}
