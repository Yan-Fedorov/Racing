using Racing.Additions;
using System;
using System.Linq;

namespace Racing.Figure
{
    public class Shell : CollidedFigures, IInterfaceItem, IAddition
    {
        private readonly Fall_Drow _figures;
        public Shell(Fall_Drow figures)
        {
            _figures = figures;

            Y = 14;
            figure = new char[,]
            {
                {'Ы'}
            };

            //ShellsCount = 20;
        }

        public int ShellsCount = 20;

        public string GetUi()
        {
            return Convert.ToString(ShellsCount);
        }
        private bool refresh = true;
        public int GetUi(int offset)
        {
            
            if (ShellsCount == 0 && refresh)
            {
                ClearConData(offset);
                refresh = false;
                return 4;
            }
            else if(ShellsCount >0)
            {
                Console.SetCursorPosition(30, offset);
                Console.Write($"Количество снарядов - {ShellsCount}, ");

                Console.SetCursorPosition(30, offset + 1);
                Console.Write("с их помощью вы можете разрушать преграды,");

                Console.SetCursorPosition(30, offset + 2);
                Console.Write("для увеличения количества вам необходимо их ловить(врезайтесь в $)");
                refresh = true;
            }
            return 4;
        }

        public bool TryApply(Collision collision)
        {
            if (collision.Symbol != '$')
                return false;

            ShellsCount++;
            _figures.RemoveBy(collision);

            return true;
        }
    }
}

