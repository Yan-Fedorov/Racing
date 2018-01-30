using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Racing.Figure.Car;
using Racing.Figure;
using Autofac;

namespace Racing
{
    public class Logic
    {
        private readonly OopCar _car;
        private readonly Fall_Drow _figures;

        public Logic(OopCar car, Fall_Drow figures)
        {
            _car = car;
            _figures = figures;
        }

        public Thread backgroundGame;

        public void BuildCanvas()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(12, i);
                Console.WriteLine('|');
            }
            Console.SetCursorPosition(0, 19);
            Console.Write("------------");
        }

        public bool gameOver;
        public void Backgroud()
        {
            Console.Clear();
            BuildCanvas();

            while (true)
            {
                var field = new char[12, 18];

                _figures.DrowTo(field);

                gameOver = _car.TestCollision(field);
                if (gameOver)
                    return;

                _car.RenderTo(field);
                DrowFig(field);


                System.Threading.Thread.Sleep(100);


                _figures.Fall();
            };
        }

        public void DrowFig(char[,] gameGround)
        {
            for (int y = 0; y < 18; y++)
            {
                Console.SetCursorPosition(0, y);
                for (int x = 0; x < 12; x++)
                {
                    Console.Write(gameGround[x, y]);
                }
            }
        }
    }
}

