using Moq;
using NUnit.Framework;
using System;
using System.Data.SqlClient;
using Tool.Data;

namespace Tool.Tests.Data {

    [TestFixture]
    public class ConnectionFactoryTests {

        const string DEFAULT_NAME = "default";
        const string INVALID_NAME = "foo";
        const string THE_NAME = "bar";
        const string DEFAULT_VALUE = "data source=default";
        const string THE_VALUE = "data source=bar";

        Mock<IConnectionStringProvider> connectionStringProviderMock;
        IConnectionFactory sut;

        [SetUp]
        public void SetUp() {
            connectionStringProviderMock = new Mock<IConnectionStringProvider>();
            connectionStringProviderMock.Setup(x => x.Get(It.IsAny<string>()))
                .Throws<ArgumentException>();
            connectionStringProviderMock.Setup(x => x.Get(DEFAULT_NAME))
                .Returns(DEFAULT_VALUE);
            connectionStringProviderMock.Setup(x => x.Get(THE_NAME))
                .Returns(THE_VALUE);

            sut = new ConnectionFactory(connectionStringProviderMock.Object);
        }

        [Test]
        public void No_Name_Returns_Default_Connection() {
            // act
            var actual = sut.Create();
            // assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<SqlConnection>(actual);
            Assert.AreEqual(DEFAULT_VALUE, actual.ConnectionString);
        }

        [TestCase("")]
        [TestCase(INVALID_NAME)]
        public void Unknown_Name_Throws_Exception(string name) {
            // assert
            var ex = Assert.Throws<ArgumentException>(() => sut.Create(name));
        }

        [Test]
        public void Existing_Name_Returns_Connection() {
            // act
            var actual = sut.Create(THE_NAME);
            // assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<SqlConnection>(actual);
            Assert.AreEqual(THE_VALUE, actual.ConnectionString);
        }
    }
}
