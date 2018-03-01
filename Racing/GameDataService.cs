using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Racing
{
    public class GameDataService
    {
        private readonly string _path;

        public GameDataService()
        {
            var localPath = Path.GetDirectoryName(GetType().Assembly.Location);
            _path = Path.Combine(localPath, @"GameData.json");
        }

        public List<GameData> LoadDatas()
        {
            if (!File.Exists(_path))
                return new List<GameData>();

            using (var file = File.OpenText(_path))
            {
                var data = file.ReadToEnd();
                var jObject = JArray.Parse(data);
                return jObject.ToObject<List<GameData>>().ToList();
            }
        }

        public void Save(GameData gameData)
        {
            var games = LoadDatas();
            games.Add(gameData);
            games = SortAndRemove(games);

            using (var file = File.Open(_path, FileMode.Create))
            using (var writer = new StreamWriter(file))
            {
                writer.Write(JsonConvert.SerializeObject(games));
                writer.Flush();
            }
        }

        public void DisplayStat(string num = null)
        {
            var games = LoadDatas();
            games = SortAndRemove(games);
            var numb = Convert.ToInt32(num);
            for (int i = 0; i < games.Count(); i++)
            {
                if (i == numb)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("В игре под названием {0}, вы набрали {1}", games[i].NameOfGame, games[i].PassesNumber);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("В игре под названием {0}, вы набрали {1}", games[i].NameOfGame, games[i].PassesNumber);
                }
            }
        }

        private List<GameData> SortAndRemove(List<GameData> games)
        {
            return games.OrderByDescending(gd => gd.PassesNumber).Take(10).ToList();

        }
    }
}
