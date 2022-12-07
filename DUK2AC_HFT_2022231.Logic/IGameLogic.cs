using DUK2AC_HFT_2022231.Models;
using System.Collections.Generic;

namespace DUK2AC_HFT_2022231.Logic
{
    public interface IGameLogic
    {
        void Create(Game item);
        void Delete(int id);
        IEnumerable<KeyValuePair<string, double>> DevsWithCheapestGamesMade();
        IEnumerable<KeyValuePair<string, int>> DevsWithMostGamesMade();
        IEnumerable<KeyValuePair<int, int>> GamesCountByOldestDev();
        Game Read(int id);
        IEnumerable<Game> ReadAll();
        void Update(Game item);
    }
}