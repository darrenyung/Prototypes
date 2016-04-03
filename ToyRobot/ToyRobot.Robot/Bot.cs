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

        private int prevXPos;
        private int prevYPos;

        #endregion

        public Bot(IBotMovement movementManager, IBotSpeech speechManager)
        {
            this.movementManager = movementManager;
            this.speechManager = speechManager;
        }


        public void SetPosition(int x, int y, string facing)
        {
            var heading = Heading.UNKNOWN;
            if (!Enum.TryParse(facing, out heading))
                throw new Exception();

            if (heading == Heading.UNKNOWN)
                throw new Exception();

            CurrXPosition = x;
            CurrYPosition = y;

            movementManager.SetFacingPosition(heading);            
        }

        public void Turn(string turnDirection)
        {
            if (string.IsNullOrEmpty(turnDirection))
                throw new Exception();

            if (turnDirection.ToLower().Equals("right"))
                movementManager.Right();
            else if (turnDirection.ToLower().Equals("left"))
                movementManager.Left();
            else
                throw new Exception();
        }

        public void Move()
        {
            prevXPos = CurrXPosition;
            prevYPos = CurrYPosition;

            if (movementManager.CurrHeading == Heading.NORTH)
                CurrYPosition = CurrYPosition + 1;
            else if (movementManager.CurrHeading == Heading.SOUTH)
                CurrYPosition = CurrYPosition - 1;
            else if (movementManager.CurrHeading == Heading.EAST)
                CurrXPosition = CurrXPosition + 1;
            else if (movementManager.CurrHeading == Heading.WEST)
                CurrXPosition = CurrXPosition - 1;
        }

        public void RollbackPosition()
        {
            CurrXPosition = prevXPos;
            CurrYPosition = prevYPos;
        }

        public int CurrXPosition { get; private set; }
        public int CurrYPosition { get; private set; }


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
            return speechManager.ReportPosition(CurrXPosition, CurrYPosition, movementManager.CurrHeading.ToString());
        }

        #endregion        
    }
}
