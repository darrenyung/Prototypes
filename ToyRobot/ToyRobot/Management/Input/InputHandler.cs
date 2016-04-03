using System;
using ToyRobot.Management.FileManagement;

namespace ToyRobot.Management.Input
{
    public class InputHandler : IInputHandler
    {
        private IFileHandler fileHandler;

        public InputHandler(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
        }

        public string ProcessArgs(string[] args)
        {
            if (args.Length == 0)
                return string.Empty;

            if (args.Length != 2 && args.Length > 0)
            {
                PrintHelp();
                return string.Empty;
            }

            var commandType = args[1];
            if (!commandType.Equals("-f"))
            {
                PrintHelp();
                return string.Empty;
            }

            return fileHandler.ReadFile(args[2]);
        }

        public bool ValidateUserInput(string input)
        {
            // TODO: need to handle PLACE
            var commandList = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (commandList.Length == 0)
                return false;

            var currCommand = commandList[0].ToUpper();

            UserInput result;
            if (!Enum.TryParse(currCommand, out result))
                return false;

            CurrUserInput = result;
            return true;

        }

        public void PrintValidInputs()
        {
            Console.WriteLine("move, left, right, report or place x,y,f (Enter 'quit' to exit)");
        }

        public void PrintHelp()
        {
            Console.WriteLine("Sample Command : ");
            Console.WriteLine("1. ToyRobot -f \"C:\\Temp\\Command\" ");
            Console.WriteLine("2. ToyRobot");
        }

        public UserInput CurrUserInput { get; private set; }
    }
}
