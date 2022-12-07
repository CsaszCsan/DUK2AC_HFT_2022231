using DUK2AC_HFT_2022231.Models;
using System.Collections.Generic;

namespace DUK2AC_HFT_2022231.Logic
{
    public interface IDeveloperLogic
    {
        void Create(Developer item);
        void Delete(int id);
        Developer Read(int id);
        IEnumerable<Developer> ReadAll();
        void Update(Developer item);
    }
}