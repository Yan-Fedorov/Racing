using System.Collections.Generic;

namespace Racing.Figure
{
    public class CollidedFigures : OopFigure
    {
        
        public List<Collision> TestCollision(char[,] gameField)
        {
            List<Collision> collidedFigures = new List<Collision>();            
            Map(gameField, (x, y, sym) =>
            {                
                    if (
                        gameField[x, y] != ' ' && gameField[x, y] != '\0'
                        && sym != ' '
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
