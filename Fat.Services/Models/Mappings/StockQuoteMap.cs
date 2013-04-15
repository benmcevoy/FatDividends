using System.Data.Entity.ModelConfiguration;

namespace Fat.Services.Models.Mappings
{
    class StockQuoteMap : EntityTypeConfiguration<StockQuote>
    {
        public StockQuoteMap()
        {
            HasKey(x => new { x.StockCode, x.ClosingDate });

            ToTable("StockQuote");
        }
    }
}

