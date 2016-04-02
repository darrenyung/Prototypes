using ToyRobot.Movement.Enum;

namespace ToyRobot.Robot.Movement
{
    public interface IBotMovement
    {
        /// <summary>
        /// Turn Left
        /// </summary>
        void Left();    

        /// <summary>
        /// Turn Right
        /// </summary>
        void Right();

        /// <summary>
        /// Set Facing position of bot
        /// </summary>
        /// <param name="heading"></param>
        void SetFacingPosition(Heading heading);

        /// <summary>
        /// Get Current facing position of bot
        /// </summary>
        Heading CurrHeading { get; }
    }
}
