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

            IMainManager mainManager = new MainManager(robotContainer.Object);
            mainManager.CreateDefaultCanvas();
            
            Assert.IsTrue(mainManager.IsCanvasSet());
        }

        [TestMethod]
        public void CreateCustomCanvas_True()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager mainManager = new MainManager(robotContainer.Object);
            mainManager.CreateCanvas(2,3);
            
            Assert.IsTrue(mainManager.IsCanvasSet());
        }

        [TestMethod]
        public void SetRobot_True()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager mainManager = new MainManager(robotContainer.Object);
            mainManager.CreateDefaultCanvas();

            mainManager.Set(0,0,"NORTH");

            var report = mainManager.Report();

            Assert.IsTrue(report.Equals("Currently in 0,0. Facing NORTH"));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SetRobot_False()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager mainManager = new MainManager(robotContainer.Object);
            mainManager.Set(0, 0, "NORTH");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetRobot_OutOfBounds()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager mainManager = new MainManager(robotContainer.Object);
            mainManager.CreateDefaultCanvas();

            mainManager.Set(10, 10, "NORTH");
        }

        [TestMethod]
        public void Move_True()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager mainManager = new MainManager(robotContainer.Object);
            mainManager.CreateDefaultCanvas();

            mainManager.Set(0, 0, "NORTH");
        }
    }
}
