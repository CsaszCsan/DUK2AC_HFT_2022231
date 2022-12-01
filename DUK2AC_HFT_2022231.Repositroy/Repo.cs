using DUK2AC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Repositroy
{
    abstract class Repo<T>:IRepo<T> where T:DataItem
    {
        protected GameShopDbContext gctx;

        public Repo(GameShopDbContext context)
        {
            this.gctx = context;
        }

        public void Create(T item)
        {
            gctx.Set<T>().Add(item);
            gctx.SaveChanges();
        }

        public abstract T Read(int ID);

        public abstract void Update(T item);

        public void Delete(int ID)
        {
            gctx.Set<T>().Remove(Read(ID));
            gctx.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return gctx.Set<T>();
        }
    }
}
