using System.Data.Entity.ModelConfiguration;

namespace Fat.Services.Models.Mappings
{
    class StockDividendMap : EntityTypeConfiguration<StockDividend>
    {
        public StockDividendMap()
        {
            HasKey(x => new { x.StockCode, x.RecordDate });

            Property(x => x.CreatedUtcDate).HasColumnName("CreateUtcDate");

            ToTable("StockDividend");
        }
    }
}