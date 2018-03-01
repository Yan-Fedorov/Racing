using System.Collections.Generic;
using System.Linq;
using Racing.Figure;

namespace Racing
{
    public class Fall_Drow
    {
        public Fall_Drow()
        {
            //figuresList = new List<OopFigure>();
        }
        private List<OopFigure> figuresList = new List<OopFigure>();

        int FallCount = 5;

        public void Fall()
        {
            FallCount++;

            if (FallCount == 6)
            {
                figuresList.Add(OopFigure.buildFigure());
                FallCount = 0;
            }

            for (int i = 0; i < figuresList.Count; i++)
            {
                figuresList[i].Y++;
            }

            figuresList = figuresList
                .Where(x => x.Y < 17)
                .ToList();
        }

        public void DrowTo(char[,] field)
        {
            for (int i = 0; i < figuresList.Count; i++)
            {
                figuresList[i].RenderTo(field);
            }
        }

        public void RemoveBy(Collision collision)
        {
            var figure = figuresList.FirstOrDefault(x => IsOverlaped(x, collision));

            if (figure != null)
                figuresList.Remove(figure);
        }

        private bool IsOverlaped(OopFigure figure, Collision collision)
        {
            int
                leftSide = figure.X,
                rightSide = figure.figure.GetLength(0) + figure.X,
                upSide = figure.Y,
                downSide = figure.figure.GetLength(1) + figure.Y;

            return leftSide <= collision.X && collision.X <= rightSide &&
                   upSide <= collision.Y && collision.Y <= downSide;
        }

        private OopFigure IsOverlaped(Collision collision)
        {
            int leftSide;
            int rightSide;
            int upSide;
            int downSide;
            OopFigure fig = new OopFigure();
            foreach (var figure in figuresList)
            {
                leftSide = figure.X;
                rightSide = figure.figure.GetLength(0) + figure.X;
                upSide = figure.Y;
                downSide = figure.figure.GetLength(1) + figure.Y;
                if (leftSide <= collision.X && collision.X <= rightSide &&
                       upSide <= collision.Y && collision.Y <= downSide)
                {
                    fig = figure;
                    break;
                }
            }
            return fig;
        }


        public bool ModifyFigure( Collision collision)
        {
            var figure = IsOverlaped(collision);
            //for (int x = 0; x < figure.figure.GetLength(0); x++)
            //{
            //    for (int y = 0; y < figure.figure.GetLength(1); y++)
            //    {
            int x = collision.X - figure.X,
                y = collision.Y - figure.Y;
                    if (figure.figure[x, y] == '@')
                    {
                        figure.figure[x, y] = ' ';
                        return true;
                    }
            //    }
            //}

            return false;
        }
    }
}
