using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Racing.Figure;

namespace Racing
{
    class Menu
    {
        private readonly Logic _logic;
        private readonly GameDataService _gameData;
        

        public Menu(Logic logic, GameDataService gameData, Userinteraction userinteraction)
        {
            _logic = logic;
            _gameData = gameData;
            
        }

        public static void Greating()
        {
            Console.WriteLine("Игра Гонки, от создателей Быков и Коров и не только");
        }
        public void StartMenu()
        {
            do
            {
                Greating();
                var answer = ConvertMenuOptions();
                switch (answer)
                {
                    case MenuOptions.StartGame:
                        _logic.Backgroud();
                        Console.ReadKey();
                        _logic.FullStop = true;
                        break;
                    case MenuOptions.Exit:
                        Console.WriteLine("Мы будем рады видеть вас еще");
                        _logic.FullStop = true;
                        return;
                    case MenuOptions.Stat:
                        _gameData.DisplayStat();
                        Console.WriteLine("Нажмите любую клавишу для выхода в основное меню");
                        Console.ReadKey();
                        break;
                    default:
                        throw new ArgumentException();
                }
                Console.Clear();
            } while (!_logic.FullStop);
        }

        public MenuOptions ConvertMenuOptions()
        {
            Console.WriteLine("Что бы начать игру нажмите 1, для выхода нажмите 2, для отображения статистики нажмите 3");
            var answer = Console.ReadLine();
            while (true)
            {
                if (int.TryParse(answer, out var num) && num > 0 && num < 4)
                    return (MenuOptions)num;
            }
        }

        public enum MenuOptions
        {
            StartGame = 1, Exit, Stat
        }
    }
}
