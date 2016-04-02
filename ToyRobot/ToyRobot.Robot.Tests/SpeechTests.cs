using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Robot.Speech;

namespace ToyRobot.Robot.Tests
{
    [TestClass]
    public class SpeechTests
    {
        #region Private Variables

        private IBotSpeech speechManager;

        #endregion

        public SpeechTests()
        {
            speechManager = new BotSpeech();
        }

        [TestMethod]
        public void ReportDanger_Test()
        {
            Assert.IsNotNull(speechManager.ReportDanger());
        }

        [TestMethod]
        public void ReportError_Test()
        {
            Assert.IsNotNull(speechManager.ReportError());
        }

        [TestMethod]
        public void ReportPosition_Test()
        {
            var result = speechManager.ReportPosition(0, 0, "North");

            Assert.IsTrue(result.Length > 0);
        }
    }
}
