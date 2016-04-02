namespace ToyRobot.Robot.Speech
{
    public interface IRobotSpeech
    {
        string ReportPosition(int x, int y, string facing);
        string ReportDanger();
        string ReportError();     
    }
}
