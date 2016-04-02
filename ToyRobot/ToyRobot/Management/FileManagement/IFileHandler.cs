namespace ToyRobot.Management.FileManagement
{
    public interface IFileHandler
    {
        /// <summary>
        /// Open file and read
        /// </summary>
        /// <param name="fileLocation"></param>
        /// <returns>File input in CSV format</returns>
        string ReadFile(string fileLocation);
    }
}
