using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Racing.Figure;

namespace Racing
{
    public class Fall_Drow
    {
        public List<OopFigure> figuresList = new List<OopFigure>();

        OopFigure f = new OopFigure();

        int FallCount = 5;
        public Fall_Drow()
        {

            f.figure = new char[,]
                    {
                     {'@', ' '},
                     {'@', '@'},
                     {'@', ' ' }
                    };


        }
        public void Fall()
        {
            //можно изменить метод фоолл, передавая туда в качестве параметром указания что нужно будет сделать с данной фигурой(вврех - вниз и на сколько)+ передевать фигуру опционально

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

            // через каждый 4 хода падает новая фигура да
            // фигуры которые вышли за границы - удалять из списка --

            // добавить ускорение фигур - есть
            // добавить стрелялки( добавление бонусных штук) при попадении на которых будет добавлятся снаряд
            // счет 
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
