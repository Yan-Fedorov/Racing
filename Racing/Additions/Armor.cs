using System;
using System.Linq;

namespace Racing.Additions
{
    public class Armor : ConsoleMethods, IInterfaceItem, IAddition
    {
        private readonly Fall_Drow _fall;
        private readonly Logic _logic;

        public Armor(Fall_Drow fall, Logic logic)
        {
            _fall = fall;
            _logic = logic;

            //ArmorCount = 1;
        }

        public int ArmorCount = 1;
        public string GetUi()
        {
            return Convert.ToString(ArmorCount);
        }
        private bool refresh = true;
        public int GetUi(int offset)
        {
            
            if (ArmorCount == 0 && refresh)
            {
                ClearConData(offset);
                refresh = false;
                return 4;
            }
            else if (ArmorCount > 0)
            {
                Console.SetCursorPosition(30, offset);
                Console.Write($"Количество доступных столкновений с преградами - {ArmorCount}, ");

                Console.SetCursorPosition(30, offset + 1);
                Console.Write("с их помощью вы можете разрушать преграды,");

                Console.SetCursorPosition(30, offset + 2);
                Console.Write("для увеличения количества вам необходимо их ловить(врезайтесь в ^)");
                refresh = true;
            }

            return 4;
        }

        public bool TryApply(Collision collision)
        {
            if (collision.Symbol == '@'){
                if (ArmorCount > 0)
                {
                    ArmorCount--;
                    
                    
                    _fall.ModifyFigure( collision);
                    return true;
                }
                else
                {
                    _logic.gameOver = true;
                    return false;
                }
            }

            if (collision.Symbol != '^')
                return false;

            ArmorCount++;
            _fall.RemoveBy(collision);

            return true;
        }
    }

}
