using System.Collections.Generic;

namespace Racing.Figure
{
    public interface IOopCar
    {
        List<Collision> TestCollision(char[,] gameField);
        void RenderTo(char[,] gameGround);
    }

    public class OopCar : CollidedFigures, IOopCar
    {
        public OopCar()
        {
            X = 6;
            Y = 14;

            figure = new[,]
            {
                {' ','^'},
                {'^','^'},
                {' ','^'},
                //{' ',' ','^',' '}
                //{' ',' ','^',' '},
                //{'^','^','^','^'},
                //{' ',' ','^',' '},
                //{' ',' ','^',' '},
            };
        }
    }
}


