using ToyRobot.Movement.Enum;

namespace ToyRobot.Robot
{
    public interface IBot
    {
        string SetPosition(int x, int y, string facing);
        string Report();
        string ReportError();
        string ReportDanger();
        int CurrXPosition { get; }
        int CurrYPosition { get; }
        void Turn(string turnDirection);
        void Move(out int newXPos, out int newYPos);
    }
}
