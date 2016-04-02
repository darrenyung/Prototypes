namespace ToyRobot.Robot.Speech
{
    public interface IBotSpeech
    {
        /// <summary>
        /// Report position of bot
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="facing"></param>
        /// <returns></returns>
        string ReportPosition(int x, int y, string facing);

        /// <summary>
        /// Report danger
        /// </summary>
        /// <returns></returns>
        string ReportDanger();

        /// <summary>
        /// Report Error
        /// </summary>
        /// <returns></returns>
        string ReportError();     
    }
}
