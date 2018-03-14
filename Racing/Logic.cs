using System;
using System.Linq;
using System.Threading;
using Racing.Figure;
using System.Collections.Generic;
using Racing.Additions;

namespace Racing
{
    public class Logic/*: ILogic*/
    {
        private readonly OopCar _car;
        private readonly Fall_Drow _figures;
        private readonly ShellEvents _shellEvents;
        private readonly Scoreboard _scoreboard;
        private readonly CarDecrease _carDecrease;
        private readonly GameData _gameData;
        private readonly GameDataService _gameDataService;
        private readonly ITimeService _timeService;

        private readonly Lazy<IEnumerable<IAddition>> _additions;

        public Logic(OopCar car, Fall_Drow figures, ShellEvents shellEvents, Scoreboard scoreboard, CarDecrease carDecrease,
            GameData gameData, GameDataService gameDataService, Lazy<IEnumerable<IAddition>> items, ITimeService timeService)
        {
            _car = car;
            _figures = figures;
            _shellEvents = shellEvents;
            _scoreboard = scoreboard;
            _carDecrease = carDecrease;
            _gameData = gameData;
            _gameDataService = gameDataService;
            _additions = items;
            _timeService = timeService;
        }

        public bool FullStop = false;

        public Thread backgroundGame;/* { get; set; }*/

        public bool ShellFly = false;

        public void BuildCanvas()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(12, i);
                Console.WriteLine('|');
            }
            Console.SetCursorPosition(0, 19);
            Console.Write("------------");

        }

        public bool gameOver = false;

        public bool Pause;

        public void Backgroud()
        {
            Console.Clear();
            BuildCanvas();
            _scoreboard.DrowBoard();

            var cycleMode = CycleMode.NoShells;

            while (true)
            {
                while (Pause) { }

                var field = new char[12, 18];

                _figures.DrowTo(field);

                var gameOverList = _car.TestCollision(field);
                ProcessingCollision(gameOverList);
                if (gameOver)
                {
                    var gamesList = _gameDataService.LoadDatas();
                    for (int i = 0; i < gamesList.Count; i++)
                    {
                        if (gamesList[i].PassesNumber < _gameData.PassesNumber)
                        {
                            Console.Clear();
                            Console.WriteLine("Введите название игры");
                            _gameData.NameOfGame = Console.ReadLine();
                            _gameDataService.Save(_gameData);
                            var numb = Convert.ToString(i);
                            _gameDataService.DisplayStat(numb);
                            break;
                        }

                    }
                    return;
                }

                _car.RenderTo(field);


                var isShellsFlyUp = _shellEvents._shells.Count != 0;
                if (isShellsFlyUp)
                {
                    if (cycleMode != CycleMode.Part1)
                        _shellEvents.TestCollition(field);

                    _shellEvents.FlyUp();
                    _shellEvents.TestCollition(field);
                    _shellEvents.DrowTo(field);
                }


                DrowFig(field);

                cycleMode = GetNextMode(cycleMode, isShellsFlyUp);
                Thread.Sleep(_timeService.GetTimeout(cycleMode != CycleMode.NoShells));

                if (cycleMode == CycleMode.Part1)
                    continue;


                _figures.Fall();


                _gameData.PassesNumber++;
                if (_carDecrease.PassNumber > 0)
                    _carDecrease.PassNumber--;
                _scoreboard.DrowBoard();
                if (_carDecrease.PassNumber == 0)
                    _carDecrease.ResizeCar();
            }
        }

        private void ProcessingCollision(List<Collision> gameOverList)
        {
            foreach (var collision in gameOverList)
            {
                if (_additions.Value.Any(addition => addition.TryApply(collision)))
                    continue;

                if (collision.Symbol == '@')
                {
                    gameOver = true;
                    return;
                }
            }
            _scoreboard.DrowBoard();
        }


        public void DrowFig(char[,] gameGround)
        {
            for (int y = 0; y < 18; y++)
            {
                Console.SetCursorPosition(0, y);
                for (int x = 0; x < 12; x++)
                {
                    Console.Write(gameGround[x, y]);
                }
            }
        }

        private enum CycleMode
        {
            NoShells = 0, Part1, Part2
        }

        private CycleMode GetNextMode(CycleMode currentMode, bool isShellsFlyUp)
        {
            var num = (int)currentMode;
            if (isShellsFlyUp)
                num += 3;

            switch (num)
            {
                case 0: // NoShells && !isShellsFlyUp
                    return CycleMode.NoShells;

                case 1: // Part1  && !isShellsFlyUp
                    return CycleMode.Part2;

                case 2: // Part2  && !isShellsFlyUp
                    return CycleMode.NoShells;

                case 3: // NoShells && isShellsFlyUp
                    return CycleMode.Part1;

                case 4: // Part1  && isShellsFlyUp
                    return CycleMode.Part2;

                case 5: // Part2  && isShellsFlyUp
                    return CycleMode.Part1;

                default:
                    throw new Exception($"Unnoun mode {currentMode}");
            }
        }
    }
}
