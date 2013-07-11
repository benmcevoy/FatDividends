using Fat.Import.Data;
using Fat.Services;
using Fat.Services.Models;
using System.Collections.Generic;
using System.IO;

namespace Fat.Import
{
    public static class EarningsCalendarImporter
    {
        public static void Import(string csv)
        {
            var csvMapper = new CsvMapper();
            //var csv = File.ReadAllText(@"D:\Dev\git\FatDividends\_documentation\D&E\earning_cba.csv");
            var mappings = new Dictionary<string, int>
                {
                    {"StockCode", 0},
                    {"Year", 1},
                    {"Period", 2},
                    {"ReportedDate", 3},
                    {"NPAT", 4},
                    {"Margin", 5},
                    {"CashFlow", 6},
                    {"EPS", 7},
                    {"DPS", 8},
                    {"ROE", 9}
                };

            var earnings = csvMapper.MapCsvTo<StockEarning>(mappings, csv, true);

            using (var service = new EarningService())
            {
                service.Add(earnings);
            }
        }

        public static void Import(StockEarning earning)
        {
            var earnings = new List<StockEarning>() { earning };

            using (var service = new EarningService())
            {
                service.Add(earnings);
            }
        }
    }
}
