using System;
using System.Text;
using System.Threading;
using Autofac;


namespace Racing
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
            using (var container = IoCBuilder.Building())
            {
                container.Resolve<Menu>().StartMenu();
            }
        }
    }
}

