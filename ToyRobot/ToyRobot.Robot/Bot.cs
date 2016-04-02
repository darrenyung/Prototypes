using System;
using ToyRobot.Movement.Enum;
using ToyRobot.Robot.Movement;
using ToyRobot.Robot.Speech;

namespace ToyRobot.Robot
{
    public class Bot : IBot
    {
        #region Private Variables

        private IBotMovement movementManager;
        private IBotSpeech speechManager;

        public int CurrXPosition { get; private set; }
        public int CurrYPosition { get; private set; }

        #endregion

        public Bot(IBotMovement movementManager, IBotSpeech speechManager)
        {
            this.movementManager = movementManager;
            this.speechManager = speechManager;
        }


        public string SetPosition(int x, int y, string facing)
        {
            var heading = Heading.Unknown;
            if (!Enum.TryParse(facing, out heading))
                return speechManager.ReportError();

            if (heading == Heading.Unknown)
                return speechManager.ReportError();

            CurrXPosition = x;
            CurrYPosition = y;

            movementManager.SetFacingPosition(heading);

            return Report();
        }
       
        public void Turn(string turnDirection)
        {
            if (string.IsNullOrEmpty(turnDirection))
                throw new Exception();

            if (turnDirection.ToLower().Equals("Right"))
                movementManager.Right();
            else if (turnDirection.ToLower().Equals("Left"))
                movementManager.Left();
            else
                throw new Exception();
        }

        public void Move(out int newXPos, out int newYPos)
        {
            newXPos = CurrXPosition;
            newYPos = CurrYPosition;
            

        }

        #region Speeches

        public string ReportDanger()
        {
            return speechManager.ReportDanger();
        }

        public string ReportError()
        {
            return speechManager.ReportError();
        }

        public string Report()
        {
            return speechManager.ReportPosition(CurrXPosition, CurrYPosition, movementManager.GetFacingPosition().ToString());
        }

        #endregion        
    }
}
