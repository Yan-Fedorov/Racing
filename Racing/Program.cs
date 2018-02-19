using System;
using System.Threading;
using Autofac;


namespace Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            //do
            //{
                Console.CursorVisible = false;
                using (var container = IoCBuilder.Building())
                {

                    using (var scope = container.BeginLifetimeScope())
                    {

                        var logica = scope.TryResolve<Logic>(out var a);
                        var menu = scope.TryResolve<Menu>(out var m);

                        var userInt = scope.TryResolve<Userinteraction>(out var b);

                        a.backgroundGame = new Thread(m.StartMenu);
                        a.backgroundGame.Start();
                        a.backgroundGame.IsBackground = true;

                        b.MoveCar();
                        Console.ReadLine();
                    }

                }
            //} while (true);
        }
    }
}

