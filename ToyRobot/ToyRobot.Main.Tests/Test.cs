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
        private const string DEFAULT_PLACEMENT = "PLACE 0,0,NORTH";

       [TestMethod]
        public void CreateDefaultCanvas_True()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager mainManager = new MainManager(robotContainer.Object);
            mainManager.CreateDefaultCanvas();
            
            Assert.IsTrue(mainManager.IsCanvasSet());
        }
        
        [TestMethod]
        public void SetRobot_True()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager mainManager = new MainManager(robotContainer.Object);
            mainManager.CreateDefaultCanvas();

            mainManager.Set(DEFAULT_PLACEMENT);

            var report = mainManager.Report();

            Assert.IsTrue(report.Equals("Currently in 0,0. Facing NORTH"));
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SetRobot_OutOfBounds()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager mainManager = new MainManager(robotContainer.Object);
            
            mainManager.Set("PLACE 10,10,NORTH");
        }

        [TestMethod]
        public void Move_True()
        {
            Mock<IBot> robotContainer = new Mock<IBot>();

            IMainManager mainManager = new MainManager(robotContainer.Object);
            mainManager.CreateDefaultCanvas();

            mainManager.Set(DEFAULT_PLACEMENT);
        }
    }
}
