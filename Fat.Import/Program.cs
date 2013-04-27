using System;

namespace Fat.Import
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args != null && args.Length > 0)
            {
                switch (args[0].ToUpperInvariant())
                {
                    case "INDEX":
                        IndexImporter.Import();
                        break;
                    case "STOCK":
                        QuoteImporter.Import(DateTime.Now.AddDays(-1));
                        break;
                }
            }
            else
            {
                IndexImporter.Import();
                QuoteImporter.Import(DateTime.Now.AddDays(-1));
            }

            //QuoteImporter.Import(new DateTime(2013, 1, 3).AddDays(-387), new DateTime(2013, 1, 3).AddDays(-189));

            //IndexImporter.Import();
            //QuoteImporter.Import(DateTime.Now.AddDays(-1));
            //DividendCalendarImporter.Import();
            //EarningsCalendarImporter.Import();
        }
    }
}
