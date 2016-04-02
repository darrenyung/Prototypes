using System;
using Ninject.Modules;
using ToyRobot.Main;

namespace ToyRobot.DependencyResolver.Module
{
    public class MainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainManager>().To<MainManager>();
        }
    }
}
