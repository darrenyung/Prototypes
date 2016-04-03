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
        private Mock<IBot> robotContainer;

        [TestInitialize]
        public void Initialize()
        {
            robotContainer = new Mock<IBot>();
        }

        [TestMethod]
        public void SetRobot_True()
        {
            robotContainer.Setup(x => x.Report()).Returns("FakeReturn");

            IMainManager mainManager = new MainManager(robotContainer.Object);            
            mainManager.Set(DEFAULT_PLACEMENT);

            var report = mainManager.Report();

            Assert.IsTrue(report.Equals("FakeReturn"));
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SetRobot_OutOfBounds()
        {
            IMainManager mainManager = new MainManager(robotContainer.Object);
            
            mainManager.Set("PLACE 10,10,NORTH");
        }

        [TestMethod]
        public void Move_True()
        {
            IMainManager mainManager = new MainManager(robotContainer.Object);            
            mainManager.Set(DEFAULT_PLACEMENT);

            mainManager.Move();
        }
    }
}
