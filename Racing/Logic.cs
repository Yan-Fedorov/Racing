using System;
using System.Linq;
using System.Threading;
using Racing.Figure;

namespace Racing
{
    public class Logic
    {
        private readonly OopCar _car;
        private readonly Fall_Drow _figures;
        private readonly Shell _shell;
        private readonly ShellEvents _shellEvents;

        public Logic(OopCar car, Fall_Drow figures, Shell shell, ShellEvents shellEvents)
        {
            _car = car;
            _figures = figures;
            _shell = shell;
            _shellEvents = shellEvents;
        }

        public Thread backgroundGame;


        static int I = 0;
        static TimerCallback tm = new TimerCallback(Increase);
        public Timer timer = new Timer(tm, null, 0, 3000);

        public bool ShellFly = false;
        public int ShellsCount = 20;

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

        
        public bool gameOver = false;

        public char[,] field = new char[12, 18];
        public void Backgroud()
        {
            Console.Clear();
            BuildCanvas();


            while (true)
            {
                field = new char[12, 18];

                _figures.DrowTo(field);

                var gameOverList = _car.TestCollision(field);
                //получаем список символов с поля с которыми столкнулись и дальше решать
                for (int i = 0; i < gameOverList.Count; i++)
                {
                    if (gameOverList[i].Symbol == '@')
                    {
                        gameOver = true;
                        return;
                    }
                    else if (gameOverList[i].Symbol == '$')
                    {
                        ShellsCount++;
                        gameOverList.RemoveAt(i);
                    }
                }
                
                

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

        public void Fire(char[,] field)
        {

            for (int i = 0; i < 2; i++)
            {
                _shellEvents.FlyUp();
                _shellEvents.TestCollition(field, _figures.figuresList);

                _shellEvents.DrowTo(field);
                DrowFig(field);
                System.Threading.Thread.Sleep(500 /*- I*/);

            }

            //в листе сделать проход по фигурам с поиском в какую попали 3
            // + у фигуры добавить метод проверки попадания и в нём-же можно менять фигуру 2
            //нарисовать полет 1
            //при столкновении изменять фигуру
            // список пуль
        }


    }
}

