using DUK2AC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Repositroy
{
    class GameRepo : Repo<Game>, IRepo<Game>
    {
        public GameRepo(GameShopDbContext gctx) : base(gctx)
        {

        }

       
    }
}
