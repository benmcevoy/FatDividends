using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fat.Services;
using Fat.Services.Models;

namespace Fat.Umbraco.API
{
    public class StockController : ApiController
    {
        private readonly StockService _stockService;

        public StockController()
        {
            _stockService = new StockService();
        }

        // GET api/Stock
        /// <summary>
        /// Get all stock information
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Stock> Get()
        {
            return _stockService.Get();
        }

        // GET api/Stock/5
        /// <summary>
        /// Get stock information for the given stockCode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Stock Get(string id)
        {
            var stock = _stockService.Get(id);

            if (stock == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return stock;
        }

        [AcceptVerbs("GET")]
        public IEnumerable<Quote> Quotes(string id)
        {
            var endDate = DateTime.Now;
            var startDate = endDate.AddDays(-90);

            return _stockService.GetQuotes(id, startDate, endDate);
        }
    }
}