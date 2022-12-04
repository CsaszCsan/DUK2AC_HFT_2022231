using DUK2AC_HFT_2022231.Models;
using DUK2AC_HFT_2022231.Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Logic
{
   public class AchievementLogic:IGameShopLogic<Achievement>
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
    }
}
