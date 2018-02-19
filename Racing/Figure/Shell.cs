using System;

namespace Racing.Figure
{
    public class Shell : CollidedFigures, IInterfaceItem
    {
        public Shell()
        {

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
            Console.Write($"Количество доступных столкновений с преградами - {ShellsCount}, ");

            return 1;
        }
    }
}
