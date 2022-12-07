using DUK2AC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Repositroy
{
    public class AchievementRepo:Repo<Achievement>,IRepo<Achievement>
    {
        public AchievementRepo(GameShopDbContext gctx) : base(gctx)
        {

        }
        public override void Update(Achievement item)
        {
            var old = Read(item.Id);
            old.Bonuspoints = item.Bonuspoints;
            gctx.SaveChanges();
        }
    }
}
