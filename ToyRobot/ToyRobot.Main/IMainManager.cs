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
        /// Position of bot on canvas
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        string Set(int xPos, int yPos, string facing);
        
        /// <summary>
        /// Move bot forward
        /// </summary>
        /// <returns></returns>
        string Move();

        /// <summary>
        /// Turn bot
        /// </summary>
        /// <param name="turnDirection"></param>
        /// <returns></returns>
        string Turn(string turnDirection);

        /// <summary>
        /// Report current position of bot
        /// </summary>
        /// <returns></returns>
        string Report();

        /// <summary>
        /// Check if canvas is set
        /// </summary>
        /// <returns></returns>
        bool IsCanvasSet();
    }
}
