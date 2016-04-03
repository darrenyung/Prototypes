using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Movement.Enum;
using ToyRobot.Robot.Movement;

namespace ToyRobot.Robot.Tests
{
    [TestClass]
    public class BotMovementTests
    {
        [TestMethod]
        public void GetFacingPosition_True()
        {
            var movementManager = new BotMovement();
            movementManager.SetFacingPosition(Heading.EAST);

            Assert.AreEqual(Heading.EAST, movementManager.CurrHeading);
        }

        [TestMethod]
        public void GetFacingPosition_False()
        {
            var movementManager = new BotMovement();
            movementManager.SetFacingPosition(Heading.EAST);

            Assert.AreNotEqual(Heading.WEST, movementManager.CurrHeading);
        }

        [TestMethod]
        public void TurnRight_True()
        {
            var movementManager = new BotMovement();
            movementManager.SetFacingPosition(Heading.EAST);
            movementManager.Right();

            Assert.AreEqual(Heading.SOUTH, movementManager.CurrHeading);
        }

        [TestMethod]
        public void TurnRight_False()
        {
            var movementManager = new BotMovement();
            movementManager.SetFacingPosition(Heading.EAST);
            movementManager.Right();

            Assert.AreNotEqual(Heading.NORTH, movementManager.CurrHeading);
        }

        [TestMethod]
        public void TurnLeft_True()
        {
            var movementManager = new BotMovement();
            movementManager.SetFacingPosition(Heading.EAST);
            movementManager.Left();

            Assert.AreEqual(Heading.NORTH, movementManager.CurrHeading);
        }

        [TestMethod]
        public void TurnLeft_False()
        {
            var movementManager = new BotMovement();
            movementManager.SetFacingPosition(Heading.EAST);
            movementManager.Left();

            Assert.AreNotEqual(Heading.SOUTH, movementManager.CurrHeading);
        }
    }
}
