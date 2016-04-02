using System;
using Ninject.Modules;
using ToyRobot.Robot.Movement;
using ToyRobot.Robot.Speech;
using ToyRobot.Robot;

namespace ToyRobot.DependencyResolver.Module
{
    public class RobotModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBot>().To<Bot>();
            Bind<IBotMovement>().To<BotMovement>();
            Bind<IBotSpeech>().To<BotSpeech>();
        }
    }
}
