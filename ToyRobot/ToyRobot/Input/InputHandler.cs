using System;
using ToyRobot.FileManagement;
using ToyRobot.Main;

namespace ToyRobot.Input
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
            
            var commands = fileHandler.ReadFile(args[2]);

            return commands;
        }

        public void PrintHelp()
        {
            Console.WriteLine("Sample Command : ");
            Console.WriteLine("1. ToyRobot -f \"C:\\Temp\\Command\" ");
            Console.WriteLine("2. ToyRobot");
        }
    }
}
