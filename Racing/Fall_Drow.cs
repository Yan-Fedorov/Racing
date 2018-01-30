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
        OopFigure a = new OopFigure();
        OopFigure b = new OopFigure();
        OopFigure c = new OopFigure();


        public Fall_Drow()
        {

            f.figure = new char[,]
                    {
                     {'@', ' '},
                     {'@', '@'},
                     {'@', ' ' }
                    };
            figuresList.Add(f);
            figuresList.Add(a);
            figuresList.Add(b);
            figuresList.Add(c);
        }

        public void Fall()
        {
            //for(int i = 0; i< figuresList.Capacity; i++)
            //{
            //    figuresList[i].Y++;
            //    if (figuresList[i].Y >= 4)
            //    {
            //        figuresList[i+1].Y++;
            //    }
            //    if (figuresList[i].Y >= 17)
            //        figuresList[i] = OopFigure.buildFigure();
            //}
            f.Y++;
            if (f.Y >= 4)
            {

            }
            if (f.Y >= 17)
                f = OopFigure.buildFigure();




            //foreach (OopFigure fig in figuresList)
            //            {
            //                fig.Y++;
            //                if (fig.Y == 17)
            //                {
            //                    fig = OopFigure.buildFigure();
            //                }
            //            }

            // через каждый 4 хода падает новая фигура
            // фигуры которые вышли за границы - удалять из списка

            // добавить ускорение фигур
            // добавить стрелялки( добавление бонусных штук) при попадении на которых будет добавлятся снаряд
            // счет 
        }

        public void DrowTo(char[,] field)
        {
            f.RenderTo(field);
            //foreach (OopFigure fig in figuresList)
            //    fig.RenderTo(field);
        }
    }
}
