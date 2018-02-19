using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class Scoreboard
    {
        private readonly IEnumerable<IInterfaceItem> _ScoreList = new List<IInterfaceItem>();
        public Scoreboard(IEnumerable<IInterfaceItem> items)
        {
            _ScoreList = items;
        }

        public void DrowBoard()
        {
            // затереть всё
            // выбрать только те елементы, которые надо отображать. Т.е. если пуль нет - то и отображать их незачем.
            // отобразить всё в столбик
            // в описании позиций учесть ограниченность длинны

            var offset = 10;
            foreach (var score in _ScoreList)
            {
                offset += score.GetUi(offset);
            }
        }


        //public void DrowScoreShells()
        //{
        //    int i = 20;
        //    foreach (var score in _ScoreList)
        //    {
        //        Console.SetCursorPosition(30, i);
        //        Console.Write($"Количество снарядов - {score.GetUi()}, " +
        //            $"с их помощью вы можете разрушать преграды, " +
        //            $"для увеличения количества вам необходимо их ловить(врезайтесь в $)");
        //        break;
        //    }
        //}
        //public void DrowScoreArmor()
        //{            
        //        Console.SetCursorPosition(30, 23);
        //        Console.Write($"Количество доступных столкновений с преградами - {_ScoreList.ElementAt(1).GetUi()}, " +
        //            $"при столкновении с преградой, их количество будет уменьшаться, " +
        //            $"для увеличения количества вам необходимо их ловить(врезайтесь в ^)");
        //}
        
    }
}
