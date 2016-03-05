using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tool.Tests {
    public class ExecutorTests {

        const string THE_COMMAND = "foo";
        const string UNKNOWN_COMMAND = "bar";

        IExecutor sut;
        Mock<ICommand> commandMock;

        [SetUp]
        public void SetUp() {
            commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.MustExecute(THE_COMMAND)).Returns(true);
            sut = new Executor(new[] { commandMock.Object });
        }

        [Test]
        public void No_Command_Arg_Throws_Exception() {
            // act
            var ex = Assert.Throws<ArgumentException>(() => sut.Execute(null));
            // assert
            Assert.AreEqual("No command was specified.", ex.Message);
        }

        [Test]
        public void Empty_Command_Arg_Throws_Exception() {
            var args = new string[] { };
            // act
            var ex = Assert.Throws<ArgumentException>(() => sut.Execute(args));
            // assert
            Assert.AreEqual("No command was specified.", ex.Message);
        }

        [Test]
        public void Unknown_Command_Arg_Throws_Exception() {
            // act
            var ex = Assert.Throws<ArgumentException>(() => sut.Execute(new[] { UNKNOWN_COMMAND }));
            // assert
            Assert.AreEqual("Not a valid command: " + UNKNOWN_COMMAND, ex.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(1)]
        public void Known_Command_Arg_Executes_Command(int result) {
            // setup
            commandMock.Setup(x => x.Execute(It.IsAny<IEnumerable<string>>()))
                .Returns(result);
            // act
            var actual = sut.Execute(new[] { THE_COMMAND });
            // assert
            Assert.AreEqual(result, actual);
        }

        [Test]
        public void First_Argument_Is_Not_Passed_To_Command() {
            const string FIRST = "first";
            const string LAST = "last";
            // arrange
            var args = new[] { THE_COMMAND, FIRST, LAST };
            Func<IEnumerable<string>, bool> test = (x) => x.Count() == 2 
                && x.First() == FIRST 
                && x.Last() == LAST;
            // act
            sut.Execute(args);
            // assert
            commandMock.Verify(x => x.Execute(It.Is<IEnumerable<string>>(y => test(y))), Times.Once());
        }
    }
}
