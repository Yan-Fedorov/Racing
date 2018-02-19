using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class GameData : IInterfaceItem
    {
        public GameData()
        {

        }
        public int PassesNumber = 0;
        public string NameOfGame;

        public int GetUi(int offset)
        {
            Console.SetCursorPosition(30, offset + 4);
            Console.Write($"Счёт - {PassesNumber}, ");
            return 3;
        }
    }
}
