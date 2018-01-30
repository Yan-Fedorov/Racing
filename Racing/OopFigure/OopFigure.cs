using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Racing.Figure.Car;

namespace Racing.Figure
{
    public class OopFigure
    {
        public int X;
        public int Y;

        public OopFigure()
        {
        }

        /*protected*/
        public char[,] figure = new char[,]
{
             
                     {'@', ' '},
                     {'@', '@'},
                     {'@', ' ' }
                    
    };

        public static OopFigure buildFigure()
        {
            Random random = new Random();
            int RandNum = random.Next(1, 4); ;

            var f = new OopFigure
            {
                X = random.Next(2, 10)
            };

            if (RandNum == 1)
            {
                f.figure = new char[,]
                {
                     {'@', ' '},
                     {'@', '@'},
                     {'@', ' ' }
                };
            }
            else if (RandNum == 2)
            {
                f.figure = new char[,]
              {
                  {'@'},
                  {'@'},
                  {'@'},
                  {'@'}
              };
            }
            else if (RandNum == 3)
            {
                f.figure = new char[,]
               {
                   {'@', '@'},
                   {'@', '@'}
               };
            }
            return f;
        }

        public void RenderTo(char[,] gameGround)
        {
            var xLength = gameGround.GetLength(0);
            var yLength = gameGround.GetLength(1);

            if (X > xLength ||
                Y > yLength) return;

            var windowLength = Math.Min(xLength, figure.GetLength(0) + X) - X;
            var windowHeight = Math.Min(yLength, figure.GetLength(1) + Y) - Y;

            /* */
            for (var x = 0; x < windowLength; x++)
                for (var y = 0; y < windowHeight; y++)
                {
                    int dextX = x + X;
                    int destY = y + Y;

                    if (figure[x, y] == ' ' || dextX < 0 || destY < 0)
                        continue;

                    gameGround[dextX, destY] = figure[x, y];
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
}
