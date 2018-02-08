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
        private readonly Shell _shell;

        public Logic(OopCar car, Fall_Drow figures, Shell shell)
        {
            _car = car;
            _figures = figures;
            _shell = shell;
        }

        public Thread backgroundGame;

        
        static int I = 0;
        static TimerCallback tm = new TimerCallback(Increase);
        public Timer timer = new Timer(tm, null, 0, 3000);

        public bool ShellFly = false;
        
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

        public char[,] field = new char[12, 18];
        public void Backgroud()
        {
            Console.Clear();
            BuildCanvas();
            int i = 0;
            
            while (true)
            {
                 field = new char[12, 18];

                _figures.DrowTo(field);

                gameOver = _car.TestCollision(field,ref _shell.Shells);
                if (gameOver)
                    return;

                _car.RenderTo(field);

                if (ShellFly)
                {
                    Fire(field);
                }
                else
                {
                    DrowFig(field);
                    System.Threading.Thread.Sleep(1000 /*- I*/);
                }
                // доводить ускорение до предела
                // в отдельный класс
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

        public static void Increase(object obj)
        {
            I += 10;
        }

        public void Fire(char [,] field)
        {

            for (int i = 0; i < 2; i++)
            {
                _shell.FlyUp();
                _shell.RenderTo(field);
                DrowFig(field);
                System.Threading.Thread.Sleep(500 /*- I*/);

                //к пуле тоже список 
            }
            //for(int y = gameGround.GetLength(1)-1; y >0; y--)
            //{
            //    if(gameGround[X,y] == '@' )
            //    {
            //        gameGround[X, y+1] = '%';
            //        break;
            //    }
            //}
            //в листе сделать проход по фигурам с поиском в какую попали 3
            // + у фигуры добавить метод проверки попадания и в нём-же можно менять фигуру 2
            //нарисовать полет 1
            //при столкновении изменять фигуру
            // список пуль
        }


    }
}

