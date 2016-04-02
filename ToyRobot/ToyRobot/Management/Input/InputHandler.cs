using System;
using ToyRobot.Management.FileManagement;
using ToyRobot.Main;

namespace ToyRobot.Management.Input
{
    public class InputHandler : IInputHandler
    {
        private IFileHandler fileHandler;
        private IMainManager mainManager;

        public InputHandler(IFileHandler fileHandler, IMainManager mainManager)
        {
            this.fileHandler = fileHandler;
            this.mainManager = mainManager;
        }

        public string ProcessArgs(string[] args)
        {
            if (args.Length == 0)
                return string.Empty;

            if(args.Length != 2 && args.Length > 0)
            {
                PrintHelp();
                return string.Empty;
            }

            var commandType = args[1];
            if(!commandType.Equals("-f"))
            {
                PrintHelp();
                return string.Empty;
            }
            
            return fileHandler.ReadFile(args[2]);
        }

        public void PrintFileContentHelp()
        {
            Console.WriteLine("File content should at least start with PLACE X,Y,F");
        }

        public void PrintHelp()
        {
            Console.WriteLine("Sample Command : ");
            Console.WriteLine("1. ToyRobot -f \"C:\\Temp\\Command\" ");
            Console.WriteLine("2. ToyRobot");
        }
    }
}
