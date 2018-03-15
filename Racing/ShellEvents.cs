using Racing.Figure;
using System.Collections.Generic;
using System.Linq;

namespace Racing
{
    public interface IShellEvents
    {
        List<Shell> _shells { get; set; }
        void TestCollition(char[,] field);
        void FlyUp();
        void DrowTo(char[,] field);
        bool HasShell();
    }

    public class ShellEvents : IShellEvents
    {
        private readonly OopCar _car;
        private readonly CollidedFigures _collidedList;
        public List<Shell> _shells { get; set; } = new List<Shell>();
        private readonly Fall_Drow _fall;

        public ShellEvents(OopCar car, CollidedFigures collidedList, Fall_Drow fall)
        {
            _car = car;
            _collidedList = collidedList;
            _fall = fall;
        }

        public void FlyUp()
        {

            for (int i = 0; i < _shells.Count; i++)
            {
                _shells[i].Y--;
            }
            _shells = _shells.Where(x => x.Y > 0).ToList();


        }

        public void DrowTo(char[,] field)
        {
            for (int i = 0; i < _shells.Count; i++)
            {
                _shells[i].RenderTo(field);

            }
        }

        public bool HasShell()
        {
            return _shells.Count != 0;
        }

        public void TestCollition(char[,] field)
        {
            var shellsToRemove = new List<Shell>();
            foreach (var shell in _shells)
            {
                var collision = shell.TestCollision(field).FirstOrDefault(x => x.Symbol == '@');
                if (collision == null)
                    continue;

                //var figure = _fall.IsOverlaped(collision);
                //if (figure == null)
                //    continue;


                if (_fall.ModifyFigure(collision))
                    shellsToRemove.Add(shell);
            }

            if (shellsToRemove.Any())
                _shells = _shells.Except(shellsToRemove).ToList();
        }



    }
}