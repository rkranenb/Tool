using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Tool.Commands.Import;
using Tool.Data;
using Tool.Data.Online;

namespace Tool.Tests.Commands.Import {

    [TestFixture]
    public class ImportCommandTests {

        ICommand sut;
        Mock<ISaveRegistrationsCommand> saveRegistrationsCommandMock;
        [SetUp]
        public void SetUp() {

            var sources = new[] { 
                new Source { Name = "First", Enabled = true }, 
                new Source { Name = "Second" } 
            };
            var sourcesQueryMock = new Mock<ISourcesQuery>();
            sourcesQueryMock.Setup(x => x.Execute()).Returns(sources);

            var registrations = new[] { 
                new Registration { Name = "John Doe" }, 
                new Registration { Name = "Jane Doe" } 
            };
            var registrationsQueryMock = new Mock<IRegistrationsQuery>();
            registrationsQueryMock.Setup(x => x.Execute(It.IsAny<Source>()))
                .Returns(registrations);

            saveRegistrationsCommandMock = new Mock<ISaveRegistrationsCommand>();

            sut = new ImportCommand(sourcesQueryMock.Object, registrationsQueryMock.Object,
                saveRegistrationsCommandMock.Object);
        }


        [Test]
        public void MustExecute_Returns_True_For_Command_Import() {
            var actual = sut.MustExecute("import");
            Assert.IsTrue(actual);
        }


        [Test]
        public void MustExecute_Returns_False_For_Every_Command_But_Import() {
            var actual = sut.MustExecute("help");
            Assert.IsFalse(actual);
        }

        [Test]
        public void Execute_With_No_Arguments_Stores_Registrations_From_All_Sources() {
            Func<IEnumerable<Registration>, bool> test = (x)=> x.Count()==2;
            // act
            sut.Execute(new string[] { });
            // assert
            saveRegistrationsCommandMock.Verify(x => x.Execute(It.Is<IEnumerable<Registration>>(y => test(y))), Times.Once());
        }

    }
}
