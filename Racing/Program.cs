using System;
using System.Threading;
using Autofac;


namespace Racing
{
    class Program
    {
        static void Main(string[] args)
        {

                Console.CursorVisible = false;
                using (var container = IoCBuilder.Building())
                {
                    container.Resolve<Menu>().StartMenu();
                }
        }
    }
}

