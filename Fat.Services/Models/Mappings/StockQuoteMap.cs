using System.Data.Entity.ModelConfiguration;

namespace Fat.Services.Models.Mappings
{
    class StockQuoteMap: EntityTypeConfiguration<StockQuote>
    {
        public StockQuoteMap()
        {
            HasKey(x => x.Code);

            ToTable("StockQuote");
        }
    }
}

    