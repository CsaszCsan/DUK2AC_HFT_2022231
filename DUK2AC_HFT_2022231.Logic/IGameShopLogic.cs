using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUK2AC_HFT_2022231.Models;

namespace DUK2AC_HFT_2022231.Logic
{
    interface IGameShopLogic<T> where T:DataItem
    {
        //CRUD methods for all of the models
        void Create(T item);
        T Read(int id);
        void Update(T item);
        void Delete(int id);
        IEnumerable<T> ReadAll();
    }
}
