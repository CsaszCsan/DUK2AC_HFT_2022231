using DUK2AC_HFT_2022231.Models;
using DUK2AC_HFT_2022231.Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Logic
{
    public class AchievementLogic : IGameShopLogic<Achievement>, IAchievementLogic
    {
        IRepo<Achievement> Repo;

        public AchievementLogic(IRepo<Achievement> repo)
        {
            this.Repo = repo;
        }

        public void Create(Achievement item)
        {
            this.Repo.Create(item);
        }

        public void Delete(int id)
        {
            this.Repo.Delete(id);
        }

        public Achievement Read(int id)
        {
            return Repo.Read(id);
        }

        public IEnumerable<Achievement> ReadAll()
        {
            return Repo.ReadAll();
        }

        public void Update(Achievement item)
        {
            Repo.Update(item);
        }
        public IEnumerable<KeyValuePair<string, int>> GetGameWithTheMostAchievementPoints()
        {
            return from x in Repo.ReadAll()
                   group x by x.game.Title into g
                   orderby g.Sum(t => t.Bonuspoints) descending
                   select new KeyValuePair<string, int>
                   (g.Key, g.Sum(t => t.Bonuspoints));
        }
        public IEnumerable<KeyValuePair<string, int>> GetAchievementsByGenre()
        {
            return from x in Repo.ReadAll()
                   group x by x.game.Genre into g
                   orderby g.Count() descending
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());
        }
    }
}
