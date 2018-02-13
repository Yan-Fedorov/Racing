using Racing.Figure;
using System.Collections.Generic;
using System.Linq;

namespace Racing
{
    public class ShellEvents
    {
        private readonly OopCar _car;
        private readonly CollidedFigures _collidedList;
        public List<Shell> shells = new List<Shell>();

        public ShellEvents(OopCar car, CollidedFigures collidedList)
        {
            _car = car;
            _collidedList = collidedList;
        }

        public void FlyUp()
        {
            for (int i = 0; i < shells.Count; i++)
            {
                shells[i].Y--;
            }

            shells = shells.Where(x => x.Y > 0).ToList();
        }

        public void DrowTo(char[,] field)
        {
            for (int i = 0; i < shells.Count; i++)
            {
                shells[i].RenderTo(field);

            }
        }

        public void TestCollition(char[,] field, List<OopFigure> figures)
        {

            //var collidedFigures = new List<List<Collision>>();

            foreach (var shell in shells)
            {
                //collidedFigures.Add(shell.TestCollision(field));
                var collision = shell.TestCollision(field).FirstOrDefault(x => x.Symbol == '@');
                if (collision == null)
                    continue;

                var figure = figures.FirstOrDefault(x => IsOverlaped(x, collision));
                if (figure == null)
                    continue;


                for (int x = 0; x < figure.figure.GetLength(0); x++)
                {
                    for (int y = 0; y < figure.figure.GetLength(1); y++)
                    {
                        if (figure.X + x == collision.X && figure.Y + y == collision.Y
                            && figure.figure[x, y] == '@')
                        {
                            figure.figure[x, y] = ' ';
                        }

                    }
                }
            }
        }


        private bool IsOverlaped(OopFigure figure, Collision collision)
        {
            int leftSide = figure.X;
            int rightSide = figure.figure.GetLength(0) + figure.X;
            int upSide = figure.Y;
            int downSide = figure.figure.GetLength(1) + figure.Y;

            return leftSide <= collision.X && collision.X <= rightSide &&
                   upSide  <= collision.Y && collision.Y <= downSide;
        }
    }
}

// нужно где то проверить что пуля столкнулась с фигурой и после этого изменить фигуру в координатах столкновения + убрать пулю
//          for (int i = 0; i<_collidedList.collidedFigures.Count(); i++)
//            {
//                for (int y = 0; y<figures[i].figure.GetLength(0); y++)
//                {
//                    for (int x = 0; x<figures[i].figure.GetLength(1); x++)
//                    {
//                        if (figures[i].X + x == XCol && figures[i].Y + y == YCol)
//                        {
//                            figures[i].figure[XCol - figures[i].X, YCol - figures[i].Y] = ' ';
//                        }
//}
//                }
//   
