using System;
using Racing.Figure;

namespace Racing
{
    public class Userinteraction
    {
        private readonly OopCar _car;
        private readonly Logic _logic;
        private readonly Shell _shell;
        private readonly ShellEvents _shellEvents;

        public ConsoleKeyInfo key_info = new ConsoleKeyInfo();

        public Userinteraction(OopCar car, Logic logic, ShellEvents shellEvents)
        {
            _car = car;
            _logic = logic;
            _shellEvents = shellEvents;
        }

        public void leftArrowEvent()
        {
            if (_car.X != 0)
            {
                _car.X--;
            }
        }
        public void rightArrowEvent()
        {
            if (_car.X != 12)
            {
                _car.X++;

            }
        }
        public void upArrowEvent()
        {
            if (_logic.ShellsCount > 0)
            {
                _logic.ShellFly = true;
                _logic.ShellsCount--;
                _shellEvents._shells.Add(new Shell { X = _car.X });
            }

        }
        public void MoveCar()
        {
            while (!_logic.gameOver)
            {
                key_info = Console.ReadKey(true);
                if (key_info.Key == ConsoleKey.RightArrow) rightArrowEvent();
                else if (key_info.Key == ConsoleKey.LeftArrow) leftArrowEvent();
                else if (key_info.Key == ConsoleKey.UpArrow) upArrowEvent();
            }

        }
    }
}
