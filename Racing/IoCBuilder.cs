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

            builder.RegisterType<Shell>().AsSelf().SingleInstance();

            builder.RegisterType<Userinteraction>().AsSelf().SingleInstance();

            builder.RegisterType<Logic>().AsSelf().SingleInstance();

            builder.RegisterType<Fall_Drow>().AsSelf().SingleInstance();
            builder.RegisterType<ShellEvents>().AsSelf().SingleInstance();

            


            return builder.Build();
        }
    }
}
