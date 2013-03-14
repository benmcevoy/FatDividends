using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fat.Quotes
{
    public interface IStockCodeProvider
    {
        string Search(string value);
    }
}
