using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Movement.Enum;
using ToyRobot.Robot.Movement;

namespace ToyRobot.Robot.Tests
{
    [TestClass]
    public class MovementTests
    {
        [TestMethod]
        public void GetFacingPosition_True()
        {
            var movementManager = new BotMovement();
            movementManager.SetFacingPosition(Heading.East);

            Assert.AreEqual(Heading.East, movementManager.GetFacingPosition());
        }

        [TestMethod]
        public void GetFacingPosition_False()
        {
            var movementManager = new BotMovement();
            movementManager.SetFacingPosition(Heading.East);

            Assert.AreNotEqual(Heading.West, movementManager.GetFacingPosition());
        }

        [TestMethod]
        public void TurnRight_True()
        {
            var movementManager = new BotMovement();
            movementManager.SetFacingPosition(Heading.East);
            movementManager.Right();

            Assert.AreEqual(Heading.South, movementManager.GetFacingPosition());
        }

        [TestMethod]
        public void TurnRight_False()
        {
            var movementManager = new BotMovement();
            movementManager.SetFacingPosition(Heading.East);
            movementManager.Right();

            Assert.AreNotEqual(Heading.North, movementManager.GetFacingPosition());
        }

        [TestMethod]
        public void TurnLeft_True()
        {
            var movementManager = new BotMovement();
            movementManager.SetFacingPosition(Heading.East);
            movementManager.Left();

            Assert.AreEqual(Heading.North, movementManager.GetFacingPosition());
        }

        [TestMethod]
        public void TurnLeft_False()
        {
            var movementManager = new BotMovement();
            movementManager.SetFacingPosition(Heading.East);
            movementManager.Left();

            Assert.AreNotEqual(Heading.South, movementManager.GetFacingPosition());
        }
    }
}
