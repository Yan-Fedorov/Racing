using System.Collections.Generic;
using Racing;

namespace Racing.Figure
{
    public class CollidedFigures : OopFigure
    {
        
        public List<Collision> TestCollision(char[,] gameField)
        {
            List<Collision> collidedFigures = new List<Collision>();
            int i = 0;

            Map(gameField, (x, y, sym) =>
            {                
                    if (
                        gameField[x, y] != ' ' && gameField[x, y] != '\0'
                        && sym != ' ' && gameField[x, y] != '$'
                        )
                    {
                    collidedFigures.Add(new Collision { X = x, Y = y, Symbol = gameField[x, y] });
                    }
                
                return false;
                
            });
            return collidedFigures;
        }
    }
}
