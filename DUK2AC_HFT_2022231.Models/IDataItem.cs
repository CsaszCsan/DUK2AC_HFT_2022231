using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUK2AC_HFT_2022231.Models
{
    public interface IDataItem <T>
    {
        T Id { get; set; }
    }
}
