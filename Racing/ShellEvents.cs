using Racing.Figure;
using System.Collections.Generic;
using System.Linq;

namespace Racing
{
    public class ShellEvents
    {
        private readonly OopCar _car;
        private readonly CollidedFigures _collidedList;
        public List<Shell> _shells = new List<Shell>();

        public ShellEvents(OopCar car, CollidedFigures collidedList)
        {
            _car = car;
            _collidedList = collidedList;
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

        public void TestCollition(char[,] field, List<OopFigure> figures)
        {
            var shellsToRemove = new List<Shell>();
            foreach (var shell in _shells)
            {                
                var collision = shell.TestCollision(field).FirstOrDefault(x => x.Symbol == '@');
                if (collision == null)
                    continue;

                var figure = figures.FirstOrDefault(x => IsOverlaped(x, collision));
                if (figure == null)
                    continue;


                if (ModifyFigure(figure, collision))
                    shellsToRemove.Add(shell);
            }

            if (shellsToRemove.Any())
                _shells = _shells.Except(shellsToRemove).ToList();
        }


        private bool IsOverlaped(OopFigure figure, Collision collision)
        {
            int leftSide = figure.X;
            int rightSide = figure.figure.GetLength(0) + figure.X;
            int upSide = figure.Y;
            int downSide = figure.figure.GetLength(1) + figure.Y;

            return leftSide <= collision.X && collision.X <= rightSide &&
                   upSide <= collision.Y && collision.Y <= downSide;
        }

        public bool ModifyFigure(OopFigure figure, Collision collision)
        {
            for (int x = 0; x < figure.figure.GetLength(0); x++)
            {
                for (int y = 0; y < figure.figure.GetLength(1); y++)
                {
                    if (figure.X + x == collision.X && figure.Y + y == collision.Y
                        && figure.figure[x, y] == '@')
                    {
                        figure.figure[x, y] = ' ';
                        return true;
                    }

                }
            }

            return false;
        }
    }
}