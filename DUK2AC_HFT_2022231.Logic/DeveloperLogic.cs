using DUK2AC_HFT_2022231.Models;
using DUK2AC_HFT_2022231.Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Logic
{
   public class DeveloperLogic:IGameShopLogic<Developer>
    {
        IRepo<Developer> Repo;
        
        public DeveloperLogic(IRepo<Developer> repo)
        {
            this.Repo = repo;
        }

        public void Create(Developer item)
        {
            this.Repo.Create(item);
        }

        public void Delete(int id)
        {
            this.Repo.Delete(id);
        }

        public Developer Read(int id)
        {
            return Repo.Read(id);
        }

        public IEnumerable<Developer> ReadAll()
        {
            return Repo.ReadAll();
        }

        public void Update(Developer item)
        {
            Repo.Update(item);
        }
    }
}
