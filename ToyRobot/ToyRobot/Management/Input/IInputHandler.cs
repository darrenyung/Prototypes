using System;
using System.Collections.Generic;

namespace ToyRobot.Management.Input
{
    public interface IInputHandler
    {
        /// <summary>
        /// Get current user input
        /// </summary>
        UserInput CurrUserInput { get; }

        /// <summary>
        /// Process user cmd input at start
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string ProcessArgs(string[] args);

        /// <summary>
        /// Print Help text
        /// </summary>
        void PrintHelp();
        
        /// <summary>
        /// Validate user input
        /// </summary>
        /// <param name="input"></param>
        /// <returns>False if input is invalid</returns>
        bool ValidateUserInput(string input);

        /// <summary>
        /// Print Valid Input help text
        /// </summary>
        void PrintValidInputs();
    }
}
