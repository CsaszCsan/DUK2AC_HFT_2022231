using DUK2AC_HFT_2022231.Models;
using System.Collections.Generic;

namespace DUK2AC_HFT_2022231.Logic
{
    public interface IAchievementLogic
    {
        void Create(Achievement item);
        void Delete(int id);
        IEnumerable<KeyValuePair<string, int>> GetAchievementsByGenre();
        IEnumerable<KeyValuePair<string, int>> GetGameWithTheMostAchievementPoints();
        Achievement Read(int id);
        IEnumerable<Achievement> ReadAll();
        void Update(Achievement item);
    }
}