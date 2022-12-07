using DUK2AC_HFT_2022231.Models;
using DUK2AC_HFT_2022231.Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Logic
{
    public class GameLogic : IGameShopLogic<Game>
    {
        IRepo<Game> Repo;

        public GameLogic(IRepo<Game> repo)
        {
            this.Repo = repo;
        }

        public void Create(Game item)
        {
            if(item.Price>=100)
            {
                throw new ArgumentException();
            }
            this.Repo.Create(item);
        }

        public void Delete(int id)
        {
            this.Repo.Delete(id);
        }

        public Game Read(int id)
        {
            return Repo.Read(id);
        }

        public IEnumerable<Game> ReadAll()
        {
            return Repo.ReadAll();
        }

        public void Update(Game item)
        {
            Repo.Update(item);
        }

        public IEnumerable<KeyValuePair<string,int>> DevsWithMostGamesMade()
        {
            return from x in Repo.ReadAll()
                   group x by x.Developer.Name into g
                   orderby g.Count() descending
                   select new KeyValuePair<string, int>
                   (g.Key,g.Count());

        }
        public IEnumerable<KeyValuePair<string, double>> DevsWithCheapestGamesMade()
        {
            return from x in Repo.ReadAll()
                   group x by x.Developer.Name into g
                   orderby g.Average(t=>t.Price) ascending
                   select new KeyValuePair<string,double>
                   (g.Key,g.Average(t=>t.Price));

        }


    }
}
