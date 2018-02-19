using System;
using System.Linq;
using System.Threading;
using Racing.Figure;
using System.Collections.Generic;
using Racing.Additions;

namespace Racing
{
    public class Logic
    {
        private readonly OopCar _car;
        private readonly Fall_Drow _figures;
        private readonly Shell _shell;
        private readonly ShellEvents _shellEvents;
        private readonly Scoreboard _scoreboard;
        private readonly Armor _armor;
        private readonly CarDecrease _carDecrease;
        private readonly GameData _gameData;
        private readonly GameDataService _gameDataService;

        private readonly List<IAddition> _additions;

        public Logic(OopCar car, Fall_Drow figures, Shell shell, ShellEvents shellEvents, Scoreboard scoreboard, Armor armor, CarDecrease carDecrease, GameData gameData, GameDataService gameDataService)
        {
            _car = car;
            _figures = figures;
            _shell = shell;
            _shellEvents = shellEvents;
            _scoreboard = scoreboard;
            _armor = armor;
            _carDecrease = carDecrease;
            _gameData = gameData;
            _gameDataService = gameDataService;
        }

        public Thread backgroundGame;
        
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

        public char[,] field = new char[12, 18];
        public void Backgroud()
        {
            Console.Clear();
            BuildCanvas();
            _scoreboard.DrowBoard();
            while (true)
            {
                field = new char[12, 18];

                _figures.DrowTo(field);
                _shellEvents.TestCollition(field, _figures.figuresList);

                var gameOverList = _car.TestCollision(field);
                ProcessingCollision(gameOverList);
                if (gameOver)
                {
                    _gameDataService.Save(_gameData);
                    return;
                }

                _car.RenderTo(field);

                if (ShellFly)
                {                    
                    Fire(field);
                }
                else
                {
                    DrowFig(field);
                    System.Threading.Thread.Sleep(1000 - TimeService.I);
                }
                _figures.Fall();
                _gameData.PassesNumber++;
                if((_gameData.PassesNumber - _carDecrease.PassNumber) % 30 == 0)
                _carDecrease.ResizeCar();
            };                        
        }
        private void ProcessingCollision(List<Collision> gameOverList)
        {
            for (int i = 0; i < gameOverList.Count; i++)
            {
                //_additions.

                if (gameOverList[i].Symbol == '@')
                {
                    if (_armor.ArmorCount > 0)
                    {
                        _armor.ArmorCount--;
                        var Collidedfigure = _figures.figuresList.FirstOrDefault(x => x.X <= gameOverList[i].X && gameOverList[i].X <= (x.figure.GetLength(0) + x.X) && x.Y <= gameOverList[i].Y && gameOverList[i].Y <= (x.figure.GetLength(1) + x.Y));
                        _shellEvents.ModifyFigure(Collidedfigure, gameOverList[i]);
                    }
                    else
                    {
                        gameOver = true;
                        return;
                    }
                }
                else if (gameOverList[i].Symbol == '$')
                {
                    _shell.ShellsCount++;
                    gameOverList.RemoveAt(i);
                    _figures.figuresList.Remove(_figures.figuresList.FirstOrDefault(x => x.figure[0, 0] == '$'));
                }
                else if (gameOverList[i].Symbol == '^')
                {
                    _armor.ArmorCount++;
                    gameOverList.RemoveAt(i);
                    _figures.figuresList.Remove(_figures.figuresList.FirstOrDefault(x => x.figure[0, 0] == '^'));

                }
                else if (gameOverList[i].Symbol == 'D')
                {
                    _carDecrease.Dencrease++;
                    _carDecrease.ResizeCar();
                    _carDecrease.PassNumber = _gameData.PassesNumber;
                    _figures.figuresList.Remove(_figures.figuresList.FirstOrDefault(x => x.figure[0, 0] == 'D'));
                }

                _scoreboard.DrowBoard();
            }
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

        
        public void Fire(char[,] field)
        {

            for (int i = 0; i < 2; i++)
            {
                _shellEvents.FlyUp();
                
                _shellEvents.TestCollition(field, _figures.figuresList);

                _shellEvents.DrowTo(field);
                DrowFig(field);
                if (i < 1)
                {
                    field = new char[12, 18];
                    _figures.DrowTo(field);
                }
                _car.RenderTo(field);
                System.Threading.Thread.Sleep(500 - TimeService.I / 2);

            }           
        }
    }
}

