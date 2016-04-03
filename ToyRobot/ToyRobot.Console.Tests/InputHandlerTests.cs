using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using ToyRobot.Management.FileManagement;
using ToyRobot.Management.Input;

namespace ToyRobot.Console.Tests
{
    [TestClass]
    public class InputHandlerTests
    {
        private Mock<IFileHandler> fileHandlerContainer;

        [TestInitialize]
        public void Initialize()
        {
            fileHandlerContainer = new Mock<IFileHandler>();
        }

        [TestMethod]
        public void ValidateUserInput_True()
        {
            var inputHandler = new InputHandler(fileHandlerContainer.Object);

            Assert.IsTrue(inputHandler.ValidateUserInput("move"));
            Assert.IsTrue(inputHandler.CurrUserInput == UserInput.MOVE);
        }

        [TestMethod]
        public void ValidateUserInput_False()
        {
            var inputHandler = new InputHandler(fileHandlerContainer.Object);

            Assert.IsFalse(inputHandler.ValidateUserInput("trysomethingelse"));
        }

        [TestMethod]
        public void ProcessArgs_EmptyInput()
        {
            var inputHandler = new InputHandler(fileHandlerContainer.Object);
            Assert.IsTrue(string.IsNullOrEmpty(inputHandler.ProcessArgs(new string[0])));
        }

        [TestMethod]
        public void ProcessArgs_FalseInput()
        {
            var inputHandler = new InputHandler(fileHandlerContainer.Object);
            Assert.IsTrue(string.IsNullOrEmpty(inputHandler.ProcessArgs(new string[5])));
        }

        [TestMethod]
        public void ProcessArgs_IncorrectInput()
        {
            var inputHandler = new InputHandler(fileHandlerContainer.Object);
            Assert.IsTrue(string.IsNullOrEmpty(inputHandler.ProcessArgs(new string[2] { "something", "something" })));
        }
        
        [TestMethod]
        public void ProcessArgs_CorrectInput()
        {
            fileHandlerContainer.Setup(x => x.ReadFile(It.IsAny<string>())).Returns("accepted");
            var inputHandler = new InputHandler(fileHandlerContainer.Object);
            Assert.IsTrue(!string.IsNullOrEmpty(inputHandler.ProcessArgs(new string[2] { "-f", "something" })));
        }
    }
}
