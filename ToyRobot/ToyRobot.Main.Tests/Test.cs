using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using ToyRobot.Main;
using ToyRobot.Robot;

namespace ToyRobot.Canvas.Tests
{
    [TestClass]
    public class Test
    {
       [TestMethod]
        public void CreateDefaultCanvas_True()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager canvasManager = new MainManager(robotContainer.Object);
            canvasManager.CreateDefaultCanvas();

            var canvas = canvasManager.Canvas;

            Assert.IsNotNull(canvas);
            Assert.AreEqual(5, canvas.GetLength(0));
            Assert.AreEqual(5, canvas.GetLength(1));
        }

        [TestMethod]
        public void CreateCustomCanvas_True()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager canvasManager = new MainManager(robotContainer.Object);
            canvasManager.CreateCanvas(2,3);

            var canvas = canvasManager.Canvas;

            Assert.IsNotNull(canvas);
            Assert.AreEqual(2, canvas.GetLength(0));
            Assert.AreEqual(3, canvas.GetLength(1));
        }

        [TestMethod]
        public void SetRobot_True()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager canvasManager = new MainManager(robotContainer.Object);
            canvasManager.CreateDefaultCanvas();

            canvasManager.Set(0,0,"NORTH");

            Assert.IsNull(canvasManager.Canvas[1, 1]);
            Assert.IsNotNull(canvasManager.Canvas[0, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SetRobot_False()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager canvasManager = new MainManager(robotContainer.Object);
            canvasManager.Set(0, 0, "NORTH");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetRobot_OutOfBounds()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager canvasManager = new MainManager(robotContainer.Object);
            canvasManager.CreateDefaultCanvas();

            canvasManager.Set(10, 10, "NORTH");
        }

        [TestMethod]
        public void ChangePosition_True()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager canvasManager = new MainManager(robotContainer.Object);
            canvasManager.CreateDefaultCanvas();

            canvasManager.Set(0, 0, "NORTH");
            Assert.IsNotNull(canvasManager.Canvas[0, 0]);
            canvasManager.Move();
            Assert.IsNull(canvasManager.Canvas[0, 0]);
            Assert.IsNotNull(canvasManager.Canvas[0, 1]);
        }
    }
}
