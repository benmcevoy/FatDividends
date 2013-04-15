using System.Data.Entity.ModelConfiguration;

namespace Fat.Services.Models.Mappings
{
    class IndexQuoteMap : EntityTypeConfiguration<IndexQuote>
    {
        public IndexQuoteMap()
        {
            HasKey(x => x.ClosingDate );

            ToTable("IndexQuote");
        }
    }
}
