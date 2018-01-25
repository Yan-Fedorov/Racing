using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    class Menu
    {
        private readonly Logic _logic;
        private readonly Figure _figure;

        public Menu(Logic logic, Figure figure)
        {
            _logic = logic;
            _figure = figure;
        }

        public static void Greating()
        {
            Console.WriteLine("Игра Гонки, от создателей Быков и Коров и не только");
        }
        public void StartMenu()
        {
            Greating();
            var answer = ConvertMenuOptions();
            switch(answer)
            {
                case MenuOptions.StartGame:
                //start
                case MenuOptions.Exit:
                    Console.WriteLine("Мы будем рады видеть вас еще");
                    return;
                default:
                    throw new ArgumentException();
            }

        }

        public MenuOptions ConvertMenuOptions()
        {
            Console.WriteLine("Что бы начать игру нажмите 1, для выхода нажмите 2");
            var answer = Console.ReadLine();
            while (true)
            {
                if (int.TryParse(answer, out var num) && num > 0 && num < 2)
                    return (MenuOptions)num;
            }
        }

        public enum MenuOptions
        {
            StartGame = 1, Exit
        }
    }
}
