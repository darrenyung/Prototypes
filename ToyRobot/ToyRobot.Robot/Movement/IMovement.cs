using ToyRobot.Movement.Enum;

namespace ToyRobot.Robot.Movement
{
    public interface IMovement
    {
        void Left();    
        void Right();

        void SetFacingPosition(Heading heading);

        Heading GetFacingPosition();
    }
}
