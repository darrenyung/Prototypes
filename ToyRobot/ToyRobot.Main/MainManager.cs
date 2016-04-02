using System;
using ToyRobot.Main.Factory;
using ToyRobot.Robot;

namespace ToyRobot.Main
{
    public class MainManager : IMainManager
    {
        #region Private Variables

        private IBot robotManager;
        private IBot[,] canvas;

        #endregion

        public MainManager(IBot robotManager)
        {
            this.robotManager = robotManager;
        }
        
        public string Set(int xPos, int yPos, string facing)
        {
            if (canvas == null)
                throw new NullReferenceException("Playing field is missing");

            canvas[xPos, yPos] = robotManager;
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

                var currRobot = canvas[currXPos, currYPos];

                robotManager.Move(out newXPos, out newYPos);
                canvas[newXPos, newYPos] = currRobot;
                canvas[currXPos, currYPos] = null;
                
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

        public string Report()
        {
            return robotManager.Report();
        }
        
        #region Canvas

        public bool IsCanvasSet()
        {
            return canvas != null;
        }

        public void CreateDefaultCanvas()
        {
            canvas = CanvasFactory.CreateDefaultCanvas();
        }

        public void CreateCanvas(int dimensionX, int dimensionY)
        {
            canvas = CanvasFactory.CreateCustomCanvas(dimensionX, dimensionY);
        }
        #endregion
    }
}
