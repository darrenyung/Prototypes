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
        
        public string Set(string placement)
        {
            try
            {
                CreateDefaultCanvas();

                var xPos = 0;
                var yPos = 0;
                var facing = string.Empty;

                // Expected Input = PLACE 0,0,NORTH
                var placeCommand = placement.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var position = placeCommand[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                
                int.TryParse(position[0], out xPos); 
                int.TryParse(position[1], out yPos); 
                facing = position[2];                

                robotManager.SetPosition(xPos, yPos, facing);
                canvas[xPos, yPos] = robotManager;

                return robotManager.Report();
            }
            catch (Exception)
            {
                throw new Exception(robotManager.ReportError());
            }
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
            var oldXPos = robotManager.CurrXPosition;
            var oldYPos = robotManager.CurrYPosition;
            
            try
            {
                var currRobot = canvas[oldXPos, oldYPos];

                robotManager.Move();
                canvas[robotManager.CurrXPosition, robotManager.CurrYPosition] = currRobot;
                canvas[oldXPos, oldYPos] = null;
                
                return robotManager.Report();
            }
            catch(IndexOutOfRangeException)
            {
                throw new Exception(robotManager.ReportDanger());
            }
            catch (Exception)
            {
                throw new Exception(robotManager.ReportError());
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
                
        #endregion
    }
}
