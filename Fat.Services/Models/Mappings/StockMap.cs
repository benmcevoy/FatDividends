using System.Data.Entity.ModelConfiguration;

namespace Fat.Services.Models.Mappings
{
    public class StockMap : EntityTypeConfiguration<Stock>
    {
        public StockMap()
        {
            HasKey(x => x.Code);

            ToTable("Stock");
        }
    }
}
