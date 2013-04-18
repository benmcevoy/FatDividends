using System;

namespace Fat.Import
{
    class Program
    {
        static void Main(string[] args)
        {
            //IndexImporter.Import();
            QuoteImporter.Import(DateTime.Now.AddDays(-1));
            //DividendCalendarImporter.Import();
            //EarningsCalendarImporter.Import();
        }
    }
}
