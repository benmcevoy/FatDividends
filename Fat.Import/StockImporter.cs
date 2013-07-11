using System.IO;
using Fat.Import.Data;

namespace Fat.Import
{
    public static class StockImporter
    {
        public static void Import()
        {
            var repository = new ImportRepository();

            var file = File.ReadAllLines(@"D:\Dev\git\FatDividends\_documentation\SQL\insert stocks.TXT");

            foreach (var line in file)
            {
                repository.Execute(line);
            }
        }
    }
}
