using System;
using ToyRobot.Movement.Enum;

namespace ToyRobot.Robot.Movement
{
    public class Movement : IMovement
    {
        private Heading currHeading;

        public Movement()
        {
            currHeading = Heading.Unknown;
        }

        public void Left()
        {
            switch (currHeading)
            {
                case Heading.North:
                    currHeading = Heading.West;
                    break;
                case Heading.West:
                    currHeading = Heading.South;
                    break;
                case Heading.South:
                    currHeading = Heading.East;
                    break;
                case Heading.East:
                    currHeading = Heading.North;
                    break;
                default:
                    throw new Exception();
            }      
        }
        
        public void Right()
        {
            switch (currHeading)
            {
                case Heading.North:
                    currHeading = Heading.East;
                    break;
                case Heading.East:
                    currHeading = Heading.South;
                    break;
                case Heading.South:
                    currHeading = Heading.West;
                    break;
                case Heading.West:
                    currHeading = Heading.North;
                    break;
                default:
                    throw new Exception();
            }           
        }

        public void SetFacingPosition(Heading heading)
        {
            currHeading = heading;
        }

        public Heading GetFacingPosition()
        {
            return currHeading;
        }
    }
}
