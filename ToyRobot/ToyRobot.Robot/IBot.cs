using ToyRobot.Movement.Enum;

namespace ToyRobot.Robot
{
    public interface IBot
    {
        /// <summary>
        /// Create new canvas and set position of the robot
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="facing"></param>
        void SetPosition(int x, int y, string facing);

        /// <summary>
        /// Report position
        /// </summary>
        /// <returns></returns>
        string Report();

        /// <summary>
        /// Report error
        /// </summary>
        /// <returns></returns>
        string ReportError();

        /// <summary>
        /// Report danger
        /// </summary>
        /// <returns></returns>
        string ReportDanger();

        /// <summary>
        /// Get Current X Pos of Robot
        /// </summary>
        int CurrXPosition { get; }

        /// <summary>
        /// Get current Y Pos of Robot
        /// </summary>
        int CurrYPosition { get; }

        /// <summary>
        /// Turn Robot
        /// </summary>
        /// <param name="turnDirection"></param>
        void Turn(string turnDirection);

        /// <summary>
        /// Move Robot
        /// </summary>
        void Move();

        /// <summary>
        /// Rollback to previous step
        /// </summary>
        void RollbackPosition();
    }
}
