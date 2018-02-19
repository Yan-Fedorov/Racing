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
    }
}
