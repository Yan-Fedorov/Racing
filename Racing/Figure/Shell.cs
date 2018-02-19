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
        }

        public int ShellsCount = 20;

        public string GetUi()
        {
            return Convert.ToString(ShellsCount);
        }

        public int GetUi(int offset)
        {            
            Console.SetCursorPosition(30, offset);
            Console.Write($"Количество снарядов - {ShellsCount}, ");

            Console.SetCursorPosition(30, offset + 1);
            Console.Write("с их помощью вы можете разрушать преграды,");

            Console.SetCursorPosition(30, offset + 2);
            Console.Write("для увеличения количества вам необходимо их ловить(врезайтесь в $)");
            return 1;
        }

        public bool TryApply(Collision collision)
        {
            if (collision.Symbol != '$')
                return false;

            ShellsCount++;
            _figures.figuresList.Remove(_figures.figuresList.FirstOrDefault(x => x.figure[0, 0] == '$'));

            return true;
        }
    }
}

