using Autofac;
using Racing.Figure;


namespace Racing
{
    public class IoCBuilder
    {
        public static IContainer Building()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<OopCar>().AsSelf().SingleInstance();
            builder.RegisterType<OopFigure>().AsSelf().SingleInstance();
            builder.RegisterType<CollidedFigures>().AsSelf().SingleInstance();

            builder.RegisterType<Userinteraction>().AsSelf().SingleInstance();

            builder.RegisterType<Logic>().AsSelf().SingleInstance();

            builder.RegisterType<Menu>().AsSelf().SingleInstance();

            builder.RegisterType<Fall_Drow>().AsSelf().SingleInstance();
            builder.RegisterType<ShellEvents>().AsSelf().SingleInstance();
            builder.RegisterType<TimeService>().AsSelf().SingleInstance();

            builder.RegisterType<Shell>().AsSelf().SingleInstance().AsImplementedInterfaces();
            builder.RegisterType<Additions.Armor>().AsSelf().SingleInstance().AsImplementedInterfaces();

            builder.RegisterType<Scoreboard>().AsSelf().SingleInstance();
            builder.RegisterType<CarDecrease>().AsSelf().SingleInstance();

            builder.RegisterType<GameData>().AsSelf().SingleInstance();
            builder.RegisterType<GameDataService>().AsSelf().SingleInstance();

            return builder.Build();
        }
    }
}
