namespace ToyRobot.Speech
{
    public interface ISpeech
    {
        string ReportPosition(int x, int y, string facing);
        string ReportDanger();
        string ReportError();     
    }
}
