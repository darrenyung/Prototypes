namespace ToyRobot.Robot.Speech
{
    public class BotSpeech : IBotSpeech
    {
        public string ReportDanger()
        {
            return "Bot: I will fall if I follow your command";
        }
        
        public string ReportPosition(int x, int y, string facing)
        {
            return string.Format("Bot: Currently in {0},{1}. Facing {2}", x, y, facing);
        }

        public string ReportError()
        {
            return string.Format("Bot: Unable to comply to instruction");
        }
    }
}
