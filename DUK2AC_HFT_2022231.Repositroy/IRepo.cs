using DUK2AC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Repositroy
{
    public interface IRepo<T> where T : DataItem
    {
        
          IQueryable<T> ReadAll();

          void Create(T item);

          T Read(int ID);

          void Update(T item);

          void Delete(int ID);
        
    }
}
