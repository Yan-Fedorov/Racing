namespace Racing.Figure.Car
{
    public class OopCar : OopFigure
    {
        public OopCar()
        {
            X = 6;
            Y = 14;

            figure = new[,]
            {
                {' ',' ','^',' '},
                {' ',' ','^',' '},
                {'^','^','^','^'},
                {' ',' ','^',' '},
                {' ',' ','^',' '},               
            };
        }

        public bool TestCollision(char[,] gameField)
        {
            return !(gameField[X, Y] == ' ' || gameField[X, Y] == '\0');
        }
    }
}
