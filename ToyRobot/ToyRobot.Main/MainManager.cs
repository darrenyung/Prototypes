using System;
using ToyRobot.Main.Factory;
using ToyRobot.Robot;

namespace ToyRobot.Main
{
    public class MainManager : IMainManager
    {
        #region Private Variables

        private IRobot robotManager;

        #endregion

        public MainManager(IRobot robotManager)
        {
            this.robotManager = robotManager;
        }


        public IRobot[,] Canvas { get; private set; }
        
        public void CreateDefaultCanvas()
        {
            Canvas = CanvasFactory.CreateDefaultCanvas();            
        }

        public void CreateCanvas(int dimensionX, int dimensionY)
        {
            Canvas = CanvasFactory.CreateCustomCanvas(dimensionX, dimensionY);            
        }

        public string Set(int xPos, int yPos, string facing)
        {
            if (Canvas == null)
                throw new NullReferenceException("Playing field is missing");

            Canvas[xPos, yPos] = robotManager;
            robotManager.SetPosition(xPos, yPos, facing);

            return robotManager.Report();
        }

        public string Turn(string turnDirection)
        {
            try {
                robotManager.Turn(turnDirection);
                return robotManager.Report();
            }
            catch (Exception)
            {
                return robotManager.ReportError();
            }
        }

        public string Move()
        {
            var currXPos = robotManager.CurrXPosition;
            var currYPos = robotManager.CurrYPosition;
            
            try
            {
                var newXPos = 0;
                var newYPos = 0;

                var currRobot = Canvas[currXPos, currYPos];

                robotManager.Move(out newXPos, out newYPos);
                Canvas[newXPos, newYPos] = currRobot;
                Canvas[currXPos, currYPos] = null;
                
                return robotManager.Report();
            }
            catch(IndexOutOfRangeException)
            {
                return robotManager.ReportDanger();
            }
            catch (Exception)
            {
                return robotManager.ReportError();
            }
        }
    }
}
