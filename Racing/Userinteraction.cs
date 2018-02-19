using System;
using Racing.Figure;

namespace Racing
{
    public class Userinteraction
    {
        private readonly OopCar _car;
        private readonly Logic _logic;        
        private readonly ShellEvents _shellEvents;
        private readonly Shell _shell;
        private readonly Scoreboard _scoreboard;
        private readonly Fall_Drow _figures;
        public ConsoleKeyInfo key_info = new ConsoleKeyInfo();

        public Userinteraction(OopCar car, Logic logic, ShellEvents shellEvents, Shell shell, TimeService timeService, Scoreboard scoreboard, Fall_Drow figures)
        {
            _car = car;
            _logic = logic;
            _shellEvents = shellEvents;
            _shell = shell;
            _scoreboard = scoreboard;
            _figures = figures;
        }
        public bool End = false;

        public void leftArrowEvent()
        {
            if (_car.X != 0 && TimeService.AllowMovement == true)
            {                                   
                    _car.X--;
                    TimeService.AllowMovement = false;
            }
        }
        public void rightArrowEvent()
        {
            if ((_car.X + _car.figure.GetLength(0)) != 12 && TimeService.AllowMovement == true)
            {                                   
                    _car.X++;
                    TimeService.AllowMovement = false;                
            }
        }
        public void upArrowEvent()
        {
            if (_shell.ShellsCount > 0 && TimeService.AllowFire == true)
            {
                _logic.ShellFly = true;
                _shell.ShellsCount--;
                _scoreboard.DrowBoard();
                if (_car.figure.GetLength(0) > 1)
                    _shellEvents._shells.Add(new Shell(_figures) { X = _car.X + (_car.figure.GetLength(0) / 2) });
                else _shellEvents._shells.Add(new Shell(_figures) { X = _car.X });
                TimeService.AllowFire = false;
            }
        }
        public void MoveCar()
        {
            while (!(_logic.gameOver/* && End*/))
            {
                key_info = Console.ReadKey(true);
                if (key_info.Key == ConsoleKey.RightArrow) rightArrowEvent();
                else if (key_info.Key == ConsoleKey.LeftArrow) leftArrowEvent();
                else if (key_info.Key == ConsoleKey.UpArrow) upArrowEvent();
            }
        }
    }
}
