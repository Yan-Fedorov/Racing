namespace Racing.Figure
{
    public class OopCar : CollidedFigures
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


