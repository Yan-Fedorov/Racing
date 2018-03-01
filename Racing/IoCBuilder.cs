using Autofac;
using Racing.Figure;


namespace Racing
{
    public class IoCBuilder
    {
        public static IContainer Building()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<OopCar>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<OopFigure>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CollidedFigures>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<Userinteraction>().AsSelf()/*.As<IUserInteraction>()*/.InstancePerLifetimeScope();

            builder.RegisterType<Logic>().AsSelf()/*.As<ILogic>()*/.InstancePerLifetimeScope();

            builder.RegisterType<Menu>().AsSelf().SingleInstance();

            builder.RegisterType<Fall_Drow>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ShellEvents>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<TimeService>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<Shell>().AsSelf().InstancePerLifetimeScope().AsImplementedInterfaces();
            builder.RegisterType<Additions.Armor>().AsSelf().InstancePerLifetimeScope().AsImplementedInterfaces();

            builder.RegisterType<Scoreboard>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CarDecrease>().AsSelf().InstancePerLifetimeScope().AsImplementedInterfaces();

            builder.RegisterType<GameData>().AsSelf().InstancePerLifetimeScope().AsImplementedInterfaces();
            builder.RegisterType<GameDataService>().AsSelf().SingleInstance();

            return builder.Build();
        }
    }
}


//builder.RegisterType<OopCar>().AsSelf().SingleInstance();
//builder.RegisterType<OopFigure>().AsSelf().SingleInstance();
//builder.RegisterType<CollidedFigures>().AsSelf().SingleInstance();

//builder.RegisterType<Userinteraction>().AsSelf().SingleInstance();

//builder.RegisterType<Logic>().AsSelf().SingleInstance();

//builder.RegisterType<Menu>().AsSelf().SingleInstance();

//builder.RegisterType<Fall_Drow>().AsSelf().SingleInstance();
//builder.RegisterType<ShellEvents>().AsSelf().SingleInstance();
//builder.RegisterType<TimeService>().AsSelf().SingleInstance();

//builder.RegisterType<Shell>().AsSelf().SingleInstance().AsImplementedInterfaces();
//builder.RegisterType<Additions.Armor>().AsSelf().SingleInstance().AsImplementedInterfaces();

//builder.RegisterType<Scoreboard>().AsSelf().SingleInstance();
//builder.RegisterType<CarDecrease>().AsSelf().SingleInstance().AsImplementedInterfaces();

//builder.RegisterType<GameData>().AsSelf().SingleInstance().AsImplementedInterfaces();
//builder.RegisterType<GameDataService>().AsSelf().SingleInstance();






//builder.RegisterType<OopCar>().AsSelf().InstancePerLifetimeScope();
//builder.RegisterType<OopFigure>().AsSelf().InstancePerDependency();
//builder.RegisterType<CollidedFigures>().AsSelf().InstancePerDependency();

//builder.RegisterType<Userinteraction>().AsSelf().InstancePerLifetimeScope();

//builder.RegisterType<Logic>().AsSelf().InstancePerDependency();

//builder.RegisterType<Menu>().AsSelf().SingleInstance();

//builder.RegisterType<Fall_Drow>().AsSelf().InstancePerDependency();
//builder.RegisterType<ShellEvents>().AsSelf().InstancePerDependency();
//builder.RegisterType<TimeService>().AsSelf().InstancePerDependency();

//builder.RegisterType<Shell>().AsSelf().InstancePerDependency().AsImplementedInterfaces();
//builder.RegisterType<Additions.Armor>().AsSelf().InstancePerDependency().AsImplementedInterfaces();

//builder.RegisterType<Scoreboard>().AsSelf().InstancePerDependency();
//builder.RegisterType<CarDecrease>().AsSelf().InstancePerDependency().AsImplementedInterfaces();

//builder.RegisterType<GameData>().AsSelf().InstancePerDependency().AsImplementedInterfaces();
//builder.RegisterType<GameDataService>().AsSelf().InstancePerDependency();