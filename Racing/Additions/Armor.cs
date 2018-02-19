using System;
using System.Linq;

namespace Racing.Additions
{
    public class Armor : IInterfaceItem, IAddition
    {
        private readonly Fall_Drow _figures;

        public Armor(Fall_Drow figures)
        {
            _figures = figures;
        }

        public int ArmorCount = 1;
        public string GetUi()
        {
            return Convert.ToString(ArmorCount);
        }

        public int GetUi(int offset)
        {
            Console.SetCursorPosition(30, offset);
            Console.Write($"Количество снарядов - {ArmorCount}, ");

            Console.SetCursorPosition(60, offset);
            Console.Write("с их помощью вы можете разрушать преграды,");

            Console.SetCursorPosition(60, offset + 1);
            Console.Write("для увеличения количества вам необходимо их ловить(врезайтесь в $)");

            return 2;
        }

        public bool TryApply(Collision collision)
        {
            if (collision.Symbol != '^')
                return false;

            ArmorCount++;
            //gameOverList.RemoveAt(i);
            _figures.figuresList.Remove(_figures.figuresList.FirstOrDefault(x => x.figure[0, 0] == '^'));

            return true;
        }
    }
}
