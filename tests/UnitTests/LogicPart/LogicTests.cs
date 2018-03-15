using System;
using System.Collections.Generic;
using NSubstitute;
using Racing;
using Racing.Additions;
using Racing.Figure;
using Xunit;

namespace UnitTests.LogicPart
{
    public class LogicTests
    {
        private string _history = "";
        private GameData _gameData;


        [Fact]
        public void Simply3Steps()
        {
            const int steps = 3;
            var logic = Build(steps);

            logic.Backgroud();

            Assert.Equal("fall-fall-fall-", _history);
            Assert.Equal(steps, _gameData.PassesNumber);
        }

        [Fact]
        public void ShortBulletFly()
        {
            const int steps = 3;
            var logic = Build(steps, addBulletLength: 1);

            logic.Backgroud();

            Assert.Equal("step-fall-half-half-fall-step-fall-", _history);
            Assert.Equal(steps, _gameData.PassesNumber);
        }

        [Fact]
        public void BulletFly()
        {
            const int steps = 4;
            var logic = Build(steps, addBulletLength: 3);

            logic.Backgroud();

            Assert.Equal("step-fall-half-half-fall-half-half-fall-step-fall-", _history);
            Assert.Equal(steps, _gameData.PassesNumber);
        }

        [Fact]
        public void LongBulletFly()
        {
            const int steps = 5;
            var logic = Build(steps, addBulletLength: 5);

            logic.Backgroud();

            Assert.Equal("step-fall-half-half-fall-half-half-fall-half-half-fall-step-fall-", _history);
            Assert.Equal(steps, _gameData.PassesNumber);
        }


        private Logic Build(int maxStep, int? addBulletLength = null)
        {
            Logic logic = null;

            var car = Substitute.For<IOopCar>();
            car.TestCollision(Arg.Any<char[,]>()).ReturnsForAnyArgs(x =>
            {
                if (_gameData.PassesNumber >= maxStep)
                    logic.gameOver = true;
                return new List<Collision>();
            });

            var figures = Substitute.For<IFall_Drow>();
            figures
                .When(x => x.Fall())
                .Do(x => _history += "fall-");

            var shellEvents = Substitute.For<IShellEvents>();
            shellEvents.HasShell().Returns(false);
            if (addBulletLength.HasValue)
            {
                var hasShells = new List<bool>();
                for (var i = 0; i < addBulletLength.Value; i++)
                    hasShells.Add(true);
                hasShells.Add(false);
                shellEvents.HasShell().Returns(false, hasShells.ToArray());
            }

            var scoreboard = Substitute.For<IScoreboard>();
            var carDecrease = Substitute.For<ICarDecrease>();
            _gameData = Substitute.For<GameData>();

            var gameDataService = Substitute.For<IGameDataService>();
            gameDataService.LoadDatas().ReturnsForAnyArgs(x => new List<GameData>());

            var items = new Lazy<IEnumerable<IAddition>>(() => new List<IAddition>());

            var timeService = Substitute.For<ITimeService>();
            if (addBulletLength.HasValue)
                timeService.GetTimeout(Arg.Any<bool>()).ReturnsForAnyArgs(x =>
                {
                    _history += x.Arg<bool>() ? "half-" : "step-";
                    return 0;
                });

            var console = Substitute.For<IConsole>();

            return logic = new Logic(car, figures, shellEvents, scoreboard, carDecrease, _gameData, gameDataService,
                items, timeService, console);
        }
    }
}
