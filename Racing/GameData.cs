using System;

namespace Racing
{
    public class GameData : ConsoleMethods ,IInterfaceItem
    {
        public GameData()
        {
            //PassesNumber = 0;

        }
        public int PassesNumber = 0;
        public string NameOfGame;

        public int GetUi(int offset)
        {
            Console.SetCursorPosition(30, offset);
            Console.Write($"Счёт - {PassesNumber}, ");
            return 2;
        }
    }
}
