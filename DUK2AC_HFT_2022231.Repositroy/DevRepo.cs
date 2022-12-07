using DUK2AC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Repositroy
{
    public class DevRepo:Repo<Developer>, IRepo<Developer>
    {
        public DevRepo(GameShopDbContext gctx) : base(gctx)
        {

        }
        public override void Update(Developer item)
        {
            var old = Read(item.Id);
            old.Name = item.Name;
            gctx.SaveChanges();
        }
    }
}
