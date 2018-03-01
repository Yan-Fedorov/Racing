using Racing.Additions;
using System;
using System.Text;

namespace Racing.Figure
{
    public class OopFigure: ConsoleMethods
    {
        public int X;
        public int Y;

        public OopFigure()
        {

        }


        /*protected*/
        public char[,] figure = new char[,]
        {
             
                     //{'@', ' '},
                     //{'@', '@'},
                     //{'@', ' ' }
                     {'$'},

        };

        public static OopFigure buildFigure()
        {
            Random random = new Random();
            int RandNum = random.Next(1, 7);

            var f = new OopFigure
            {
                X = random.Next(0, 10)
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
            else if (RandNum == 4)
            {
                f.figure = new char[,]
               {
                   {'$'},
               };
            }
            else if (RandNum == 5)
            {
                f.figure = new char[,]
               {
                   {'^'},
               };
            }
            else if (RandNum == 6)
            {
                f.figure = new char[,]
               {
                   {'D'},
               };
            }
            return f;
        }

        public void RenderTo(char[,] gameGround)
        {
            Map(gameGround, (x, y, sym) =>
            {
                
                if (sym != ' ' )
                    gameGround[x, y] = sym;

                return false;
            });
        }

        protected void Map(char[,] gameGround, Func<int, int, char, bool> func)
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

                    if (dextX < 0 || destY < 0)
                        continue;

                    if (func(dextX, destY, figure[x, y]))
                        return ;
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
