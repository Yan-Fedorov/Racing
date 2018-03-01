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
        private readonly Shell _shell;
        private readonly ShellEvents _shellEvents;
        private readonly Scoreboard _scoreboard;
        private readonly CarDecrease _carDecrease;
        private readonly GameData _gameData;
        private readonly GameDataService _gameDataService;

        private readonly Lazy<IEnumerable<IAddition>> _additions;

        public Logic(OopCar car, Fall_Drow figures, Shell shell, ShellEvents shellEvents, Scoreboard scoreboard, CarDecrease carDecrease, 
            GameData gameData, GameDataService gameDataService, Lazy<IEnumerable<IAddition>> items)
        {
            _car = car;
            _figures = figures;
            _shell = shell;
            _shellEvents = shellEvents;
            _scoreboard = scoreboard;
            _carDecrease = carDecrease;
            _gameData = gameData;
            _gameDataService = gameDataService;
            _additions = items;


            //FullStop = false;
            //ShellFly = false;
            //gameOver = false;
            //Pause = false;
            //field = new char[12, 18];
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

        public char[,] field = new char[12, 18];
        public void Backgroud()
        {
            Console.Clear();
            BuildCanvas();
            _scoreboard.DrowBoard();
            int FireAnanble = 0;
            while (true)
            {
                while (Pause)
                {

                }
                field = new char[12, 18];

                _figures.DrowTo(field);
                _shellEvents.TestCollition(field/*, _figures.figuresList*/);

                var gameOverList = _car.TestCollision(field);
                ProcessingCollision(gameOverList);
                if (gameOver)
                {
                    var gamesList = _gameDataService.LoadDatas();
                    for (int i = 0; i< gamesList.Count; i ++)
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


                if (_shellEvents._shells.Count > 0)
                {
                    _shellEvents.FlyUp();
                    _shellEvents.TestCollition(field/*, _figures.figuresList*/);
                    _shellEvents.DrowTo(field);
                    System.Threading.Thread.Sleep(500 - TimeService.I / 2);
                    FireAnanble++;
                    DrowFig(field);
                    _car.RenderTo(field);

                }


                if (_shellEvents._shells.Count == 0 || FireAnanble == 2)
                {
                    if (FireAnanble == 2)
                    {
                        _figures.Fall();
                        FireAnanble = 0;
                    }
                    else
                    {
                        DrowFig(field);
                        System.Threading.Thread.Sleep(1000 - TimeService.I);
                        _figures.Fall();
                    }


                }
                _gameData.PassesNumber++;
                if (_carDecrease.PassNumber > 0)
                    _carDecrease.PassNumber--;
                _scoreboard.DrowBoard();
                if (_carDecrease.PassNumber == 0)
                    _carDecrease.ResizeCar();
            };
        }
        //public void Fire(char[,] field)
        //{

        //    for (int i = 0; i < 2; i++)
        //    {
        //        _shellEvents.FlyUp();

        //        _shellEvents.TestCollition(field, _figures.figuresList);

        //        _shellEvents.DrowTo(field);
        //        DrowFig(field);
        //        if (i < 1)
        //        {
        //            field = new char[12, 18];
        //            _figures.DrowTo(field);
        //        }
        //        _car.RenderTo(field);
        //        System.Threading.Thread.Sleep(500 - TimeService.I / 2);

        //    }
        //}
        private void ProcessingCollision(List<Collision> gameOverList)
        {
            foreach (var collision in  gameOverList)
            {
                if (_additions.Value.Any(addition => addition.TryApply(collision)))
                    continue;

                if(collision.Symbol == '@')
                {
                    gameOver = true;
                    return;
                }
                    

                /*
                foreach (var addition in _additions.Value)
                {
                    var FindFig = addition.TryApply(gameOverList[i]);
                    if (FindFig)
                        break;

                    if (gameOver == true)
                        return;

                }
                */
                //if (_armor.ArmorCount > 0)
                //{
                //    _armor.ArmorCount--;
                //    var Collidedfigure = _figures.figuresList.FirstOrDefault(x => x.X <= gameOverList[i].X && gameOverList[i].X <= (x.figure.GetLength(0) + x.X) && x.Y <= gameOverList[i].Y && gameOverList[i].Y <= (x.figure.GetLength(1) + x.Y));
                //    _shellEvents.ModifyFigure(Collidedfigure, gameOverList[i]);



                //foreach (var addition in _additions.Value)
                //{

                //    if(addition.TryApply(gameOverList[i])) 
                //        break;
                //}
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

    }
}

// if (gameOverList[i].Symbol == '@')
//                {
//                    if (_armor.ArmorCount > 0)
//                    {
//                        _armor.ArmorCount--;
//                        var Collidedfigure = _figures.figuresList.FirstOrDefault(x => x.X <= gameOverList[i].X && gameOverList[i].X <= (x.figure.GetLength(0) + x.X) && x.Y <= gameOverList[i].Y && gameOverList[i].Y <= (x.figure.GetLength(1) + x.Y));
//_shellEvents.ModifyFigure(Collidedfigure, gameOverList[i]);
//                    }
//                    else
//                    {
//                        gameOver = true;
//                        return;
//                    }
//                }
//                else if (gameOverList[i].Symbol == '$')
//                {
//                    _shell.ShellsCount++;
//                    gameOverList.RemoveAt(i);
//                    _figures.figuresList.Remove(_figures.figuresList.FirstOrDefault(x => x.figure[0, 0] == '$'));
//                }
//                else if (gameOverList[i].Symbol == '^')
//                {
//                    _armor.ArmorCount++;
//                    gameOverList.RemoveAt(i);
//                    _figures.figuresList.Remove(_figures.figuresList.FirstOrDefault(x => x.figure[0, 0] == '^'));

//                }
//                else if (gameOverList[i].Symbol == 'D')
//                {
//                    _carDecrease.Dencrease++;
//                    _carDecrease.ResizeCar();
//                    _carDecrease.PassNumber = 30;
//                    _figures.figuresList.Remove(_figures.figuresList.FirstOrDefault(x => x.figure[0, 0] == 'D'));
//                }


//namespace Racing
//{
//    public class Logic
//    {
//        private readonly OopCar _car;
//        private readonly Fall_Drow _figures;
//        private readonly Shell _shell;
//        private readonly ShellEvents _shellEvents;
//        private readonly Scoreboard _scoreboard;
//        private readonly Armor _armor;
//        private readonly CarDecrease _carDecrease;
//        private readonly GameData _gameData;
//        private readonly GameDataService _gameDataService;

//        private readonly IEnumerable<IAddition> _additions = new List<IAddition>();

//        public Logic(OopCar car, Fall_Drow figures, Shell shell, ShellEvents shellEvents, Scoreboard scoreboard, Armor armor, CarDecrease carDecrease, GameData gameData, GameDataService gameDataService, IEnumerable<IAddition> items)
//        {
//            _car = car;
//            _figures = figures;
//            _shell = shell;
//            _shellEvents = shellEvents;
//            _scoreboard = scoreboard;
//            _armor = armor;
//            _carDecrease = carDecrease;
//            _gameData = gameData;
//            _gameDataService = gameDataService;
//            _additions = items;
//        }

//        public bool FullStop = false;

//        public Thread backgroundGame;

//        public bool ShellFly = false;

//        public void BuildCanvas()
//        {
//            for (int i = 0; i < 20; i++)
//            {
//                Console.SetCursorPosition(12, i);
//                Console.WriteLine('|');
//            }
//            Console.SetCursorPosition(0, 19);
//            Console.Write("------------");

//        }

//        public bool gameOver = false;

//        public char[,] field = new char[12, 18];
//        public void Backgroud()
//        {
//            Console.Clear();
//            BuildCanvas();
//            _scoreboard.DrowBoard();
//            bool FireAnanble = false;
//            while (true)
//            {
//                field = new char[12, 18];

//                _figures.DrowTo(field);
//                _shellEvents.TestCollition(field, _figures.figuresList);

//                var gameOverList = _car.TestCollision(field);
//                ProcessingCollision(gameOverList);
//                if (gameOver)
//                {
//                    var gamesList = _gameDataService.LoadDatas();
//                    foreach (var game in gamesList)
//                    {
//                        if (game.PassesNumber < _gameData.PassesNumber)
//                        {
//                            Console.Clear();
//                            Console.WriteLine("Введите название игры");
//                            _gameData.NameOfGame = Console.ReadLine();
//                            _gameDataService.Save(_gameData);
//                            break;
//                        }

//                    }
//                    return;
//                }

//                _car.RenderTo(field);

//                if (ShellFly)
//                {
//                    Fire(field);
//                }
//                else
//                {
//                    DrowFig(field);
//                    System.Threading.Thread.Sleep(1000 - TimeService.I);
//                }
//                _figures.Fall();
//                _gameData.PassesNumber++;
//                if (_carDecrease.PassNumber > 0)
//                    _carDecrease.PassNumber--;
//                _scoreboard.DrowBoard();
//                if (_carDecrease.PassNumber == 0)
//                    _carDecrease.ResizeCar();
//            };
//        }
//        public void Fire(char[,] field)
//        {

//            for (int i = 0; i < 2; i++)
//            {
//                _shellEvents.FlyUp();

//                _shellEvents.TestCollition(field, _figures.figuresList);

//                _shellEvents.DrowTo(field);
//                DrowFig(field);
//                if (i < 1)
//                {
//                    field = new char[12, 18];
//                    _figures.DrowTo(field);
//                }
//                _car.RenderTo(field);
//                System.Threading.Thread.Sleep(500 - TimeService.I / 2);

//            }
//        }
//        private void ProcessingCollision(List<Collision> gameOverList)
//        {
//            for (int i = 0; i < gameOverList.Count; i++)
//            {

//                if (gameOverList[i].Symbol == '@')
//                {
//                    if (_armor.ArmorCount > 0)
//                    {
//                        _armor.ArmorCount--;
//                        var Collidedfigure = _figures.figuresList.FirstOrDefault(x => x.X <= gameOverList[i].X && gameOverList[i].X <= (x.figure.GetLength(0) + x.X) && x.Y <= gameOverList[i].Y && gameOverList[i].Y <= (x.figure.GetLength(1) + x.Y));
//                        _shellEvents.ModifyFigure(Collidedfigure, gameOverList[i]);
//                    }
//                    else
//                    {
//                        gameOver = true;
//                        return;
//                    }
//                }
//                foreach (var addition in _additions)
//                {
//                    addition.TryApply(gameOverList[i]);
//                }



//                _scoreboard.DrowBoard();
//            }
//        }

//        public void DrowFig(char[,] gameGround)
//        {
//            for (int y = 0; y < 18; y++)
//            {
//                Console.SetCursorPosition(0, y);
//                for (int x = 0; x < 12; x++)
//                {
//                    Console.Write(gameGround[x, y]);
//                }
//            }
//        }

//    }
//}

