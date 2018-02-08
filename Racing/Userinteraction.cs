using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Racing.Figure.Car;
using Racing.Figure;

namespace Racing
{
    public class Userinteraction
    {
        private readonly OopCar _car;
        private readonly Logic _logic;
        private readonly Shell _shell;

        public ConsoleKeyInfo key_info = new ConsoleKeyInfo();

        public Userinteraction(OopCar car, Logic logic, Shell shell)
        {
            _car = car;
            _logic = logic;
            _shell = shell;
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
            if (_shell.Shells > 0)
            {
                _logic.ShellFly = true;
                _shell.Shells--;
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
