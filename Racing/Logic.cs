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

        public Logic(OopCar car)
        {
            _car = car;
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
            var i = 0;
            BuildCanvas();
            do
            {
                Console.WriteLine(i);
                OopFigure figure = OopFigure.buildFigure();

                FallFig(figure);
                i++;

            } while (!gameOver);
        }


        public void FallFig(OopFigure figure)
        {
            for (var y = 0; y < 18; y++)
            {
                var field = new char[12, 18];
                figure.RenderTo(field);

                gameOver = _car.TestCollision(field);

                _car.RenderTo(field);
                DrowFig(field);

                if (gameOver)
                    break;
                // что делать с gameOver

                figure.Y++;

                System.Threading.Thread.Sleep(100);
            }

        }

        public void DrowFig(char[,] gameGround, char[,] gameField = null)
        {
            if (gameField == null)
                gameField = gameGround;

            for (int y = 0; y < 18; y++)
            {
                Console.SetCursorPosition(0, y);
                for (int x = 0; x < 12; x++)
                {
                    Console.Write(gameField[x, y]);
                }
            }
        }
        //public void GameOver(int randFig, int randPos, char[,] field)
        //{
        //    for (int x = 0; x < 12; x++)
        //    {
        //        if (field[x, 16] == '@' && _car.car[x] == '^')
        //        {
        //            gameOver = true;
        //            break;
        //        }
        //        else
        //        {
        //            gameOver = false;
        //        }
        //    }
        //}
    }
}

