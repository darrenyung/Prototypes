using ToyRobot.Robot;

namespace ToyRobot.Main.Factory
{
    public static class CanvasFactory
    {
        public static IBot[,] CreateDefaultCanvas()
        {
            return new IBot[5,5];
        }
    }
}
