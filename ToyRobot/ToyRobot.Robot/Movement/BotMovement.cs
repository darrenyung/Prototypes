using System;
using ToyRobot.Movement.Enum;

namespace ToyRobot.Robot.Movement
{
    public class BotMovement : IBotMovement
    {

        public BotMovement()
        {
            CurrHeading = Heading.UNKNOWN;
        }

        public Heading CurrHeading { get; private set; }

        public void Left()
        {
            switch (CurrHeading)
            {
                case Heading.NORTH:
                    CurrHeading = Heading.WEST;
                    break;
                case Heading.WEST:
                    CurrHeading = Heading.SOUTH;
                    break;
                case Heading.SOUTH:
                    CurrHeading = Heading.EAST;
                    break;
                case Heading.EAST:
                    CurrHeading = Heading.NORTH;
                    break;
                default:
                    throw new Exception();
            }
        }

        public void Right()
        {
            switch (CurrHeading)
            {
                case Heading.NORTH:
                    CurrHeading = Heading.EAST;
                    break;
                case Heading.EAST:
                    CurrHeading = Heading.SOUTH;
                    break;
                case Heading.SOUTH:
                    CurrHeading = Heading.WEST;
                    break;
                case Heading.WEST:
                    CurrHeading = Heading.NORTH;
                    break;
                default:
                    throw new Exception();
            }
        }

        public void SetFacingPosition(Heading heading)
        {
            CurrHeading = heading;
        }        
    }
}
