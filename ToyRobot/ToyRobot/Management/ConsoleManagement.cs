using ToyRobot.Management.FileManagement;
using ToyRobot.Management.Input;
using ToyRobot.Main;
using System;

namespace ToyRobot
{
    public class ConsoleManagement
    {
        #region Private Variables

        private IInputHandler inputHandler;
        private IFileHandler fileHandler;
        private IMainManager mainManager;

        #endregion

        public ConsoleManagement(IInputHandler inputHandler, IFileHandler fileHandler, IMainManager mainManager)
        {
            this.inputHandler = inputHandler;
            this.fileHandler = fileHandler;
            this.mainManager = mainManager;
        }

        public void ProcessInput(string[] args)
        {
            var fileContent = inputHandler.ProcessArgs(args);
            if (string.IsNullOrEmpty(fileContent))
                Start();
            else
            {
                Start(fileContent);
            }
        }

        public void Start(string initialSetup)
        {
            var commands = initialSetup.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (commands.Length == 0)
                Start();

            foreach (var command in commands)
            {
                if (!command.ToLower().Contains("place"))
                {
                    inputHandler.PrintFileContentHelp();
                    break;
                }
            }
        }

        public void Start()
        {
            if (!mainManager.IsCanvasSet())
                mainManager.CreateDefaultCanvas();

            Console.WriteLine("Ready");
            Console.WriteLine("Available Commands : move, left, right, report (Enter 'quit' to exit)");
            var userInput = string.Empty;
            userInput = Console.ReadLine();
            while(userInput != "quit")
            {
            }
        }
    }
}
