using System.Collections.Generic;
using System.Linq;
using Racing.Figure;

namespace Racing
{
    public class Fall_Drow
    {
        public List<OopFigure> figuresList = new List<OopFigure>();

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
    }
}
