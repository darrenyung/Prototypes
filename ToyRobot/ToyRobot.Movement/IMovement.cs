using ToyRobot.Movement.Enum;

namespace ToyRobot.Movement
{
    public interface IMovement
    {
        bool Left();    
        bool Right();

        void SetFacingPosition(Heading heading);

        Heading GetFacingPosition();
    }
}
