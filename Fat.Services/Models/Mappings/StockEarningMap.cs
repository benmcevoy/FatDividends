using System.Data.Entity.ModelConfiguration;

namespace Fat.Services.Models.Mappings
{
    class StockEarningMap : EntityTypeConfiguration<StockEarning>
    {
        public StockEarningMap()
        {
            HasKey(x => new { x.StockCode, x.ReportedDate });

            Property(x => x.CreatedUtcDate).HasColumnName("CreateUtcDate");

            ToTable("StockEarning");
        }
    }
}
