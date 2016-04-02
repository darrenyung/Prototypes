using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Management.Input
{
    public interface IInputHandler
    {
        string ProcessArgs(string[] args);
        void PrintHelp();
        void PrintFileContentHelp();
    }
}
