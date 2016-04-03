
namespace ToyRobot.Main
{
    public interface IMainManager
    {   
        /// <summary>
        /// Creates a canvas and position of bot on it
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        string Set(string placement);
        
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
