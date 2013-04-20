﻿using System;
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
            var csv = File.ReadAllText(@"D:\Dev\git\FatDividends\_documentation\scrape_output_750.csv");
            var mappings = new Dictionary<string, int>
                {
                    {"StockCode", 0},
                    {"ExDate", 1},
                    {"Amount", 2},
                    {"Franked", 3},
                    {"FrankingCredit", 4},
                    {"PayableDate", 5}
                };

            var stockDividends = csvMapper.MapCsvTo<StockDividend>(mappings, csv, true).ToList();

            UpdateClosingPrice(stockDividends);
            
            using (var service = new DividendService())
            {
                service.Add(stockDividends);
            }
        }

        private static void UpdateClosingPrice(IEnumerable<StockDividend> stockDividends)
        {
            using (var service = new QuoteService())
            {
                foreach (var dividend in stockDividends)
                {
                    dividend.StockCode = dividend.StockCode.ToUpper();

                    var current = dividend;
                    var closingDate = current.ExDate.AddDays(-1);
                    var closingQuote = service.Get(q =>
                        q.ClosingDate == closingDate
                        && q.StockCode == current.StockCode);

                    if (closingQuote != null)
                    {
                        dividend.ClosingPrice = closingQuote.Price;
                        dividend.RecordDate = closingQuote.ClosingDate;
                    }
                }
            }
        }
    }
}

