using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fat.Import
{
    class Program
    {
        static void Main(string[] args)
        {
            ImportStocks();
        }

        private static void ImportStocks()
        {
            var repository = new Data.StockRepository();

            var file = System.IO.File.ReadAllLines(@"D:\Dev\git\FatDividends\_documentation\SQL\insert stocks.TXT");

            foreach (var line in file)
            {
                repository.Execute(line);
            }
        }
    }
}
