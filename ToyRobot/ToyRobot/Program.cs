using System.Collections.Generic;

using Ninject;
using Ninject.Modules;
using ToyRobot.Input;
using ToyRobot.FileManagement;
using ToyRobot.DependencyResolver.Module;

namespace ToyRobot
{
    public class Program
    {
        static void Main(string[] args)
        {
            SetUpNinject();

            if (args.Length > 0)
            {

            }
        }    

        static void SetUpNinject()
        {
            var kernal = new StandardKernel();
            kernal.Bind<IInputHandler>().To<InputHandler>();
            kernal.Bind<IFileHandler>().To<FileHandler>();

            var modules = new List<INinjectModule>
            {
                new MainModule(),
                new RobotModule()
            };

            kernal.Load(modules);
        }
    }
}
