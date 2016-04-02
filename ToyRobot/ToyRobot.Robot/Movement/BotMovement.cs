using System;
using ToyRobot.Movement.Enum;

namespace ToyRobot.Robot.Movement
{
    public class BotMovement : IBotMovement
    {

        public BotMovement()
        {
            CurrHeading = Heading.Unknown;
        }

        public Heading CurrHeading { get; private set; }

        public void Left()
        {
            switch (CurrHeading)
            {
                case Heading.North:
                    CurrHeading = Heading.West;
                    break;
                case Heading.West:
                    CurrHeading = Heading.South;
                    break;
                case Heading.South:
                    CurrHeading = Heading.East;
                    break;
                case Heading.East:
                    CurrHeading = Heading.North;
                    break;
                default:
                    throw new Exception();
            }
        }

        public void Right()
        {
            switch (CurrHeading)
            {
                case Heading.North:
                    CurrHeading = Heading.East;
                    break;
                case Heading.East:
                    CurrHeading = Heading.South;
                    break;
                case Heading.South:
                    CurrHeading = Heading.West;
                    break;
                case Heading.West:
                    CurrHeading = Heading.North;
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
