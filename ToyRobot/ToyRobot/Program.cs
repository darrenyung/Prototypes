using System.Collections.Generic;

using Ninject;
using Ninject.Modules;
using ToyRobot.Management.Input;
using ToyRobot.Management.FileManagement;
using ToyRobot.DependencyResolver.Module;
using ToyRobot.Main;

namespace ToyRobot
{
    public class Program
    {
        static void Main(string[] args)
        {
            var kernel = SetUpNinject();            
            var consoleManagement = new ConsoleManagement(
                    kernel.Get<IInputHandler>(), 
                    kernel.Get<IFileHandler>(),
                    kernel.Get<IMainManager>());

            if (args.Length > 0)
                consoleManagement.ProcessInput(args);
            else
                consoleManagement.Start();
        }    

        static IKernel SetUpNinject()
        {
            IKernel kernal = new StandardKernel();
            kernal.Bind<IInputHandler>().To<InputHandler>();
            kernal.Bind<IFileHandler>().To<FileHandler>();

            var modules = new List<INinjectModule>
            {
                new MainModule(),
                new RobotModule()
            };

            kernal.Load(modules);

            return kernal;
        }
    }
}
