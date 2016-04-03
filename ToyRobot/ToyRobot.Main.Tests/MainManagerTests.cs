using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using ToyRobot.Main;
using ToyRobot.Robot;

namespace ToyRobot.Canvas.Tests
{
    [TestClass]
    public class MainManagerTests
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

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void MoveToOutsideArea()
        {
            robotContainer.Setup(x => x.CurrXPosition).Returns(5);
            robotContainer.Setup(x => x.CurrXPosition).Returns(5);
            robotContainer.Setup(x => x.Move()).Verifiable();
            robotContainer.Setup(x => x.Report()).Returns("1");

            robotContainer.Setup(x => x.SetPosition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Verifiable();
            
            IMainManager mainManager = new MainManager(robotContainer.Object);
            mainManager.Set("PLACE 4,4,NORTH");

            mainManager.Move();
        }

        [TestMethod]
        public void Turn_Valid()
        {
            robotContainer.Setup(x => x.Report()).Returns("1");
            robotContainer.Setup(x => x.Turn(It.IsAny<string>())).Verifiable();

            IMainManager mainManager = new MainManager(robotContainer.Object);

            Assert.IsTrue(!string.IsNullOrEmpty(mainManager.Turn("left")));
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ReportBeforeUsingPlaceCommand()
        {
            IMainManager mainManager = new MainManager(robotContainer.Object);
            mainManager.Report();
        }
    }
}
