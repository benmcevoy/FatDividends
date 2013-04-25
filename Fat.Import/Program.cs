using System;

namespace Fat.Import
{
    class Program
    {
        static void Main(string[] args)
        {
            //QuoteImporter.Import(new DateTime(2013, 1, 3).AddDays(-387), new DateTime(2013, 1, 3).AddDays(-189));

            //IndexImporter.Import();
            //QuoteImporter.Import(DateTime.Now.AddDays(-1));
            DividendCalendarImporter.Import();
            //EarningsCalendarImporter.Import();
        }
    }
}
