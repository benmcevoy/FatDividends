using System.Data.Entity;
using Fat.Services.Models.Mappings;

namespace Fat.Services.Models
{
    public class FatDataContext : DbContext
    {
        public FatDataContext() : base("name=Entities")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = true;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // defaults
            
            // explicit
            modelBuilder.Configurations.Add(new StockMap());
            modelBuilder.Configurations.Add(new StockQuoteMap());
            modelBuilder.Configurations.Add(new IndexQuoteMap());
        }
    
        public DbSet<Stock> Stocks { get; set; }

        public virtual DbSet<StockQuote> StockQuotes { get; set; }

        public virtual DbSet<IndexQuote> IndexQuotes { get; set; }
    }
}
