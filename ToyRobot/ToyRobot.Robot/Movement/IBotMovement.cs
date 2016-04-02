using ToyRobot.Movement.Enum;

namespace ToyRobot.Robot.Movement
{
    public interface IBotMovement
    {
        void Left();    
        void Right();

        void SetFacingPosition(Heading heading);

        Heading GetFacingPosition();
    }
}
