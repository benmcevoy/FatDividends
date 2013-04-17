using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fat.Import.Data;
using Fat.Services;
using Fat.Services.Models;

namespace Fat.Import
{
    static class DividendCalendarImporter
    {
        public static void Import()
        {
            var csvMapper = new CsvMapper();
            var csv = File.ReadAllText(@"D:\Dev\git\FatDividends\_documentation\D&E\dividend_cba.csv");
            var mappings = new Dictionary<string, int>
                {
                    {"StockCode", 0},
                    {"ExDate", 1},
                    {"Amount", 2},
                    {"Franked", 3},
                    {"RecordDate", 4},
                    {"PayableDate", 5}
                };

            var dividends = csvMapper.MapCsvTo<StockDividend>(mappings, csv, true);

            using (var service = new DividendService())
            {
                service.Add(dividends);
            }
        }
    }
}

