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
            var commands = initialSetup.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            if (commands.Length == 0)
                Start();

            bool hasPlacement = false;

            foreach (var command in commands)
            {
                if (!command.ToLower().Contains("place") && !hasPlacement)
                    continue;

                UserCommand(command);
                hasPlacement = true;
            }
        }

        public void Start()
        {
            Console.WriteLine("Ready");
            Console.WriteLine("Available Commands :");
            inputHandler.PrintValidInputs();
            var userInput = string.Empty;
            userInput = Console.ReadLine().ToUpper();    
            while(userInput != "QUIT")
            {
                try
                {
                    UserCommand(userInput);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }

                userInput = Console.ReadLine().ToUpper();
            }
        }

        private void UserCommand(string userInput)
        {
            if (!inputHandler.ValidateUserInput(userInput))
                inputHandler.PrintValidInputs();
            else
            {
                switch (inputHandler.CurrUserInput)
                {
                    case UserInput.LEFT:
                    case UserInput.RIGHT:
                        Console.WriteLine(mainManager.Turn(inputHandler.CurrUserInput.ToString()));
                        break;
                    case UserInput.MOVE:
                        Console.WriteLine(mainManager.Move());
                        break;
                    case UserInput.REPORT:
                        Console.WriteLine(mainManager.Report());
                        break;
                    case UserInput.PLACE:
                        Console.WriteLine(mainManager.Set(userInput));
                        break;
                    default:
                        inputHandler.PrintValidInputs();
                        break;
                }
            }
        }
    }
}
