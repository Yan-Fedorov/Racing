﻿using System;
using System.Collections.Generic;

namespace Racing
{
    public interface IScoreboard
    {
        void DrowBoard();
    }

    public class Scoreboard: IScoreboard
    {
        private readonly Lazy<IEnumerable<IInterfaceItem>> _ScoreList  /*new Lazy<List<IInterfaceItem>>()*/;
        public Scoreboard(Lazy<IEnumerable<IInterfaceItem>> items)
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
            foreach (var score in _ScoreList.Value)
            {
                if (score == null)
                    continue;
                offset += score.GetUi(offset);
            }

        }
    }
}
