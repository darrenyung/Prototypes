namespace ToyRobot.Robot.Speech
{
    public interface IBotSpeech
    {
        string ReportPosition(int x, int y, string facing);
        string ReportDanger();
        string ReportError();     
    }
}
