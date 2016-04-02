using ToyRobot.Robot;

namespace ToyRobot.Main
{
    public interface IMainManager
    {
        /// <summary>
        /// Create a canvas
        /// </summary>        
        void CreateDefaultCanvas();

        /// <summary>
        /// Create a custom canvas
        /// </summary>
        /// <param name="dimensionX"></param>
        /// <param name="dimensionY"></param>        
        void CreateCanvas(int dimensionX, int dimensionY);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        string Set(int xPos, int yPos, string facing);

        IRobot[,] Canvas { get; }

        string Move();

        string Turn(string turnDirection);
    }
}
