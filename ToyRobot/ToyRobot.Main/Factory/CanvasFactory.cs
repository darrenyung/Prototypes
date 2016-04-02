using ToyRobot.Robot;

namespace ToyRobot.Main.Factory
{
    public static class CanvasFactory
    {
        public static IRobot[,] CreateDefaultCanvas()
        {
            return new IRobot[5,5];
        }

        public static IRobot[,] CreateCustomCanvas(int dimensionX, int dimensionY)
        {
            return new IRobot[dimensionX, dimensionY];
        }
    }
}
