﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Racing
{
    public class Figure
    {
        public char[,] figure = new char[,]
        {
            //new char[]{'@', '@', '@'},
            //new char[]{' ', '@', ' '}
            {'@', ' '},
            {'@', '@'},
            {'@', ' '}
        };
      

        public int Y;
        public int X;


        public void CopyTo(char[,] gameGround, int targetX, int targetY)
        {
            var xLength = gameGround.GetLength(0);
            var yLength = gameGround.GetLength(1);

            if (targetX > xLength ||
                targetY > yLength) return;

            var windowLength = Math.Min(xLength, figure.GetLength(0) + targetX) - targetX;
            var windowHeight = Math.Min(yLength, figure.GetLength(1) + targetY) - targetY;

            for (var x = 0; x < windowLength; x++)
                for (var y = 0; y < windowHeight; y++)
                    if (figure[x, y] != ' ')
                    {
                        if (targetX < 0 )
                        {
                            var newX =x + (0 - targetX);
                            if(newX >= windowLength)
                            {
                                return;
                            }
                            
                            gameGround[x , y ] = figure[newX, y];
                        } 
                        else if (targetY < 0)
                        {
                            var newY = y + (0 - targetY);
                            if (newY >= windowHeight)
                            {
                                return;
                            }
                            gameGround[x , y ] = figure[x, newY];
                        }
                        else if(targetX<0 && targetY < 0)
                        {
                            var newY = y + (0 - targetY);
                            var newX = x + (0 - targetX);
                            if (newY >= windowHeight || newX >= windowLength)
                            {
                                return;
                            }
                            gameGround[x , y ] = figure[newX, newY];
                        }
                        else
                        gameGround[x + targetX, y + targetY] = figure[x, y];
                    }
        }

        public static string ToString(char[,] mas)
        {
            var sb = new StringBuilder();

            for (int y = 0, my = mas.GetLength(1); y < my; y++)
            {
                for (var x = 0; x < mas.GetLength(0); x++)
                    sb.Append(mas[x, y]);

                sb.AppendLine();
            }
            return sb.ToString();
        }
    }

    public class Logic
    {
        public Logic()
        {
            c = 6;
            car[c] = '^';
        }
        //падающие фигурки
        int c = 6;

        Random random = new Random();
        int randNum = 0;
        int randPos = 0;
        
        char[,] gameGround = new char[12, 18];
        public ConsoleKeyInfo key_info = new ConsoleKeyInfo();
        public Thread backgroundGame = new Thread(Backgroud);
        public bool fix = true;
        int dropTime = 600;
        public bool gameOver = false;


        //машинка
        char[] car = new char[12];


        public void leftArrowEvent()
        {
            if (c != 0)
            {
                car[c] = ' ';
                c--;
                car[c] = '^';
                DrowCar();

            }
        }
        public void rightArrowEvent()
        {
            if (c != 17)
            {
                car[c] = ' ';
                c++;
                car[c] = '^';
                DrowCar();

            }
        }
        public void DrowCar()
        {

            Console.SetCursorPosition(0, 17);
            for (int x = 0; x < 12; x++)
            {
                Console.Write(car[x]);
            }
        }

        public int SelectFigure()
        {
            randNum = random.Next(1, 4);
            return randNum;

        }
        public int SelectPosition()
        {
            randPos = random.Next(2, 10);
            return randPos;
        }

        public Figure buildFigure(int randNum)
        {
            //тут у это х
            var f = new Figure();
            if (randNum == 1)
            {
                f.figure = new char[,]
                {
                     {'@', ' '},
                     {'@', '@'},
                     {'@', ' ' }
                };                
            }
            else if (randNum == 2)
            {
                f.figure = new char[,]
              {
                  {'@'},
                  {'@'},
                  {'@'},
                  {'@'}
              };                
            }
            else if (randNum == 3)
            {
                f.figure = new char[,]
               {
                   {'@', '@'},
                   {'@', '@'}
               };                
            }
            return f;            
        }
        public void DrowFig(char[,] gameField = null)
        {
            if (gameField == null)
                gameField = gameGround;

            for (int y = 0; y < 18; y++)
            {
                Console.SetCursorPosition(0, y);
                for (int x = 0; x < 12; x++)
                {
                    Console.Write(gameField[x, y]);
                    if( y == 17)
                    {
                        Console.Write(car[x]);
                    }
                    //mas[,] = gameGround[x, y]
                }
            }
        }

        public void FallFig(Figure figure, Logic logic, int randPosition, int randFig)
        {
            for (var y = 0; y < 18; y++)
            {
                var field = new char[12, 18];
                figure.CopyTo(field, randPosition, y);
                logic.DrowFig(field);

                GameOver(randFig, y, randPos);

                System.Threading.Thread.Sleep(50);
            }
            
        }
        public void FullClean()
        {
            for (int y = 0; y < 18; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    if (gameGround[x, y] == '@') gameGround[x, y] = ' ';
                }
            }
        }
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
        public void MoveCar()
        {
            DrowCar();
            while (!gameOver)
            {
                key_info = Console.ReadKey(true);
                if (key_info.Key == ConsoleKey.RightArrow) rightArrowEvent();
                else if (key_info.Key == ConsoleKey.LeftArrow) leftArrowEvent();
            }

        }

        public void GameOver(int randFig, int y, int randPos)
        {
            for (int x = 0; x < 12; x++)
            {
                if (gameGround[x, 17] == '@' && c == x)
                {
                    gameOver = true;
                }
                else
                {
                    gameOver = false;
                }
            }
            //if ( randFig == 1)
            //{
            //    if (y == 17)
            //    {
            //        if (c == randPos + 1)
            //            gameOver = true;
            //        else
            //        {
            //            gameOver = false;
            //        }
            //    }
            //    else if(y == 18)
            //    {
            //        for (int i = 0; i < 3; i++)
            //        {
            //            if (c == randPos + i)
            //                gameOver = true;
            //            else
            //            {
            //                gameOver = false;
            //            }
            //        }
            //    }
            //}
            //else if(y == 18 && randFig == 2) 
            //{
            //    for (int i = 0; i < 4; i++)
            //    {
            //        if (c == randPos +i)
            //            gameOver = true;
            //        else gameOver = false;
            //    }
            //}
            //else if((y == 17 && randFig == 3) || (y ==18 && randFig == 3))
            //{
            //    for(int i = 0; i<2; i++)
            //    {
            //        if (c == randPos + i)
            //            gameOver = true;
            //        else
            //        {
            //            gameOver = false;
            //        }
            //    }
            //}

            //return gameOver;
        }
        public static void Backgroud()
        {

            Logic logic = new Logic();
            Figure figure = new Figure();
            Console.Clear();
            var i = 0;
            logic.BuildCanvas();
            do
            {
                Console.WriteLine(i);

                var randFig = logic.SelectFigure();
                var randPos = logic.SelectPosition();
                figure = logic.buildFigure(randFig);
                //logic.FullClean();

                logic.FallFig(figure, logic, randPos, randFig);
                i++;

            } while (!logic.gameOver);
            //Console.ReadLine();
        }



    }
}

