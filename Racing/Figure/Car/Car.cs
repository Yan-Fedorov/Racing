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
                {' ',' ','^',' '}
                //{' ',' ','^',' '},
                //{'^','^','^','^'},
                //{' ',' ','^',' '},
                //{' ',' ','^',' '},
            };
        }

        public bool TestCollision(char[,] gameField,ref int shells)
        {
            for (int x = 0; x < figure.GetLength(0); x++)
            {
                for (int y = 0; y < figure.GetLength(1); y++)
                {
                    if (
                        gameField[X + x, Y + y] != ' ' && gameField[X + x, Y + y] != '\0'
                        && figure[x, y] != ' ' && gameField[X + x, Y + y] != '$'
                        )
                        return true;
                    else if(gameField[X + x, Y + y] == '$' && figure[x, y] != ' ')
                    {
                        shells++;
                    }
                }
            }

            return false;

        }
    }
}

