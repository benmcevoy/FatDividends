using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fat.Services.Models;

namespace Fat.Services
{
    public class StockService
    {
        private readonly FatDataContext _context;

        public StockService()
        {
            _context = new FatDataContext();
        }

        public IEnumerable<Stock> Get()
        {
            return _context.Stocks.AsEnumerable();
        }

        public Stock Get(string id)
        {
            var stock = _context.Stocks.Find(id);

            return stock;
        }
    }
}
