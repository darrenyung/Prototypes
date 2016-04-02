using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Input
{
    public interface IInputHandler
    {
        string ProcessArgs(string[] args);

        void PrintHelp();
    }
}
