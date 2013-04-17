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
            modelBuilder.Configurations.Add(new StockDividendMap());
            modelBuilder.Configurations.Add(new StockEarningMap());
        }

        public virtual DbSet<Stock> Stocks { get; set; }

        public virtual DbSet<StockQuote> StockQuotes { get; set; }

        public virtual DbSet<IndexQuote> IndexQuotes { get; set; }

        public virtual DbSet<StockDividend> StockDividends { get; set; }

        public virtual DbSet<StockEarning> StockEarnings { get; set; }
    }
}
