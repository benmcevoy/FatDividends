using System;

namespace Fat.Import
{
    class Program
    {
        static void Main(string[] args)
        {
            IndexImporter.Import();
            QuoteImporter.Import(new DateTime(2013, 4, 16));
            //DividendCalendarImporter.Import();
            //EarningsCalendarImporter.Import();
        }
    }
}
