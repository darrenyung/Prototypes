using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using ToyRobot.Movement.Enum;
using ToyRobot.Robot.Movement;
using ToyRobot.Robot.Speech;

namespace ToyRobot.Robot.Tests
{

    [TestClass]
    public class BotTests
    {
        #region Private Variables

        private Mock<IBotMovement> robotMovementContainer;
        private Mock<IBotSpeech> robotSpeechContainer;
        private IBot bot;

        #endregion

        [TestInitialize]
        public void Initialize()
        {
            robotMovementContainer = new Mock<IBotMovement>();
            robotSpeechContainer = new Mock<IBotSpeech>();
        }

        [TestMethod]        
        public void SetPosition_True()
        {
            bot = new Bot(robotMovementContainer.Object, robotSpeechContainer.Object);
            bot.SetPosition(2, 3, "NORTH");

            Assert.AreEqual(2, bot.CurrXPosition);
            Assert.AreEqual(3, bot.CurrYPosition);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SetPosition_False()
        {
            bot = new Bot(robotMovementContainer.Object, robotSpeechContainer.Object);
            bot.SetPosition(2, 3, "FAKEDIRECTION");            
        }

        [TestMethod]        
        public void Turn_True()
        {
            bot = new Bot(robotMovementContainer.Object, robotSpeechContainer.Object);
            bot.SetPosition(2, 3, "NORTH");
            
            bot.Turn("right");
            bot.Turn("left");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Turn_False()
        {
            bot = new Bot(robotMovementContainer.Object, robotSpeechContainer.Object);
            bot.Turn("up");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Turn_NoDirectionProvided()
        {
            bot = new Bot(robotMovementContainer.Object, robotSpeechContainer.Object);
            bot.Turn(string.Empty);
        }

        [TestMethod]
        public void MoveSouth_True()
        {
            robotMovementContainer.Setup(x => x.CurrHeading).Returns(Heading.SOUTH);
            bot = new Bot(robotMovementContainer.Object, robotSpeechContainer.Object);
            bot.SetPosition(2, 3, Heading.SOUTH.ToString());
            
            bot.Move();

            Assert.IsTrue(bot.CurrYPosition == 2);
            Assert.IsTrue(bot.CurrXPosition == 2);
        }
        
        [TestMethod]
        public void MoveNorth_True()
        {
            robotMovementContainer.Setup(x => x.CurrHeading).Returns(Heading.NORTH);
            bot = new Bot(robotMovementContainer.Object, robotSpeechContainer.Object);
            bot.SetPosition(2, 3, Heading.NORTH.ToString());

            bot.Move();

            Assert.IsTrue(bot.CurrYPosition == 4);
            Assert.IsTrue(bot.CurrXPosition == 2);
        }

        [TestMethod]
        public void MoveEast_True()
        {
            robotMovementContainer.Setup(x => x.CurrHeading).Returns(Heading.EAST);
            bot = new Bot(robotMovementContainer.Object, robotSpeechContainer.Object);
            bot.SetPosition(2, 3, Heading.EAST.ToString());

            bot.Move();

            Assert.IsTrue(bot.CurrYPosition == 3);
            Assert.IsTrue(bot.CurrXPosition == 3);
        }
        
        [TestMethod]
        public void MoveWest_True()
        {
            robotMovementContainer.Setup(x => x.CurrHeading).Returns(Heading.WEST);
            bot = new Bot(robotMovementContainer.Object, robotSpeechContainer.Object);
            bot.SetPosition(2, 3, Heading.WEST.ToString());

            bot.Move();

            Assert.IsTrue(bot.CurrYPosition == 3);
            Assert.IsTrue(bot.CurrXPosition == 1);
        }
        
        [TestMethod]
        public void TestRollbackPosition_True()
        {
            robotMovementContainer.Setup(x => x.CurrHeading).Returns(Heading.EAST);
            bot = new Bot(robotMovementContainer.Object, robotSpeechContainer.Object);
            bot.SetPosition(2, 3, Heading.EAST.ToString());

            bot.Move();

            Assert.IsTrue(bot.CurrYPosition == 3);
            Assert.IsTrue(bot.CurrXPosition == 3);

            bot.RollbackPosition();
            
            Assert.IsTrue(bot.CurrYPosition == 3);
            Assert.IsTrue(bot.CurrXPosition == 2);
        }
    }
}
