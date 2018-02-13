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

                using (var scope = container.BeginLifetimeScope())
                {

                    var logica = scope.TryResolve<Logic>(out var a);

                    var userInt = scope.TryResolve<Userinteraction>(out var b);

                    a.backgroundGame = new Thread(a.Backgroud);
                    a.backgroundGame.Start();
                    a.backgroundGame.IsBackground = true;

                    b.MoveCar();
                    Console.ReadLine();

                }

            }
        }
    }
}
//var figure = new Figure();
//var gameField = new char[12, 18];

//figure.CopyTo(gameField, 4, 4);
//Logic l = new Logic();

//l.DrowFig(gameField);
//Console.ReadLine();

//figure.CopyTo(gameField, -1, -1);
//l.DrowFig(gameField);
//Console.ReadLine();

//figure.CopyTo(gameField, -1, 0);
//l.DrowFig(gameField);
//Console.ReadLine();


//figure.CopyTo(gameField, 10, 17);
//l.DrowFig(gameField);
//Console.ReadLine();
//return;


//var f2 = new Figure
//{
//    figure = new char[,] {
//        {'x', ' ', ' '  },
//        {' ', 'x', ' '  },
//        {' ', ' ', 'x'  }
//    }
//};
//f2.CopyTo(gameField, 1, 2);
//l.DrowFig(gameField);

//Console.ReadLine();

//Console.Clear();
//for (var y = 0; y < 20; y++)
//{
//    var field = new char[12, 18];
//    figure.CopyTo(field, 2, y);
//    l.DrowFig(field);
//    System.Threading.Thread.Sleep(500);
//}

//return;
