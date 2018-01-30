using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Racing.Figure;
using Racing.Figure.Car;


namespace Racing
{
    public class IoCBuilder
    {
        public static IContainer Building()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<OopCar>().AsSelf().SingleInstance();

            builder.RegisterType<Userinteraction>().AsSelf().SingleInstance();

            builder.RegisterType<Logic>().AsSelf().SingleInstance();

            builder.RegisterType<Fall_Drow>().AsSelf().SingleInstance();


            return builder.Build();
        }
    }
}
