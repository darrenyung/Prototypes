using System;
using ToyRobot.Movement.Enum;

namespace ToyRobot.Movement
{
    public class Movement : IMovement
    {
        private Heading currHeading;
        private MovementOption currMovementOption;

        public Movement()
        {
            currHeading = Heading.Unknown;
        }

        public bool Left()
        {
            if (!currMovementOption.Left)
                return false;

            if (currHeading == Heading.North)
                currHeading = Heading.West;
            else if (currHeading == Heading.West)
                currHeading = Heading.South;
            else if (currHeading == Heading.South)
                currHeading = Heading.East;
            else if (currHeading == Heading.East)
                currHeading = Heading.North;

            return true;
        }
        
        public bool Right()
        {
            if (!currMovementOption.Right)
                return false;

            if (currHeading == Heading.North)
                currHeading = Heading.East;
            else if (currHeading == Heading.East)
                currHeading = Heading.South;
            else if (currHeading == Heading.South)
                currHeading = Heading.West;
            else if (currHeading == Heading.West)
                currHeading = Heading.North;

            return true;
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
